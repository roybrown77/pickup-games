$(document).ready(function () {
    $('#pagination').pagination({
        items: 100,
        itemsOnPage: 10,
        cssStyle: 'light-theme'/*,
        hrefTextPrefix: '/Games/Search/' + $('#Location').val() + '?page=',
        hrefTextSuffix: getUrlSearchParameters(),*/
    });

    $('#pagination > ul > li.active').click(function () {
        var temp = 1;
    });

    google.maps.event.addDomListener(window, 'load', initializeMap);
});

function onSearchGamesSuccess(data, status, xhr) {
    if (data.Status == "Success") {
        updateGameList(data.Games);
        createMap(data.SearchLocationLat, data.SearchLocationLng);
    } else {
        alert(data.Message);
    }
}

function onSearchGamesComplete() {
    updateUrl(1);    
}

function pageGames(index) {
    var searchFormParameters = $('#searchgamesform').serialize();
    var encodedSearchFormParametersArray = searchFormParameters.split('&');
    var urlSearchParameterArray = [];

    $.each(encodedSearchFormParametersArray, function (i, elem) {
        if (elem.split("=")[1] != "") {
            elem = elem.split("=")[0].toLowerCase() + '=' + elem.split("=")[1];
            urlSearchParameterArray.push(elem);
        }
    });

    if (urlSearchParameterArray.length == 0) {
        return;
    }

    var urlSearchParameterString = urlSearchParameterArray.join('&') + '&index=' + index;    

    $.ajax({        
        url: '/Games/SearchByAjax',
        type: 'POST',
        data: urlSearchParameterString,
        //dataType: "json",
        //contentType:'application/json; charset=utf-8',
        success: function(data) {
            if (data.Status == "Success") {
                updateGameList(data.Games);
                createMap(data.SearchLocationLat, data.SearchLocationLng);                
            } else {
                alert(data.Message);
            }
        },
        complete: function() {
            updateUrl(index);
        }
    });
}

function updateUrl(index) {
    var urlSearchParameterArray = getUrlSearchParameterArray();

    if (urlSearchParameterArray.length > 0) {
        window.history.pushState("searchcriteria", "searchcriteria", "/Games/Search/" + $('#Location').val() + "/" + index + "?" + urlSearchParameterArray.join("&"));
    } else {
        window.history.pushState("searchcriteria", "searchcriteria", "/Games/Search/" + $('#Location').val() + "/" + index);
    }
}

function convertFormToObject(form) {
    var array = $(form).serializeArray();
    var newObject = {};

    $.each(array, function () {
        newObject[this.name] = this.value || null;
    });

    return newObject;
}

function showHideGameSearchFilter() {
    $('#searchgames').toggle(500);
};

function getUrlSearchParameterString() {    
    var urlSearchParameterString = '';
    var urlSearchParameterArray = getUrlSearchParameterArray();
    urlSearchParameterString = urlSearchParameterArray.join("&");    
    return urlSearchParameterString;
}

function getUrlSearchParameterArray() {
    var urlSearchParameterArray = [];

    var searchFormParameters = $("#searchgamesform").serializeArray();
    var encodedSearchFormParameters = $.param(searchFormParameters);
    var encodedSearchFormParametersArray = encodedSearchFormParameters.split('&');

    $.each(encodedSearchFormParametersArray, function(index, elem) {
        if (elem.split("=")[1] != "" && elem.split("=")[0].toLowerCase() != "location") {
            elem = elem.split("=")[0].toLowerCase() + '=' + elem.split("=")[1];
            urlSearchParameterArray.push(elem);
        }
    });

    return urlSearchParameterArray;
}

function updateGameList(games) {
    var templateWithData = Mustache.to_html($("#gamesTemplate").html(), { games: games });
    $("#gamelist").empty().html(templateWithData);
}
    
function joinGame(id) {
    $.ajax({
        type: 'POST',
        url: "Games/Join",        
        data: { gameId: id },        
    success: function (data) {
        if (data.Status == "Success") {
            alert('joined!');
        } else {
        }
    }
});
}

function watchGame(id) {
    $.ajax({
        type: 'POST',
        url: "Games/Watch",
        data: { gameId: id },
        success: function (data) {
            if (data.Status == "Success") {
                alert('watching!');
            } else {
            }
        }
    });
}
    
function deleteGame(id) {
    $.ajax({
        type: 'POST',
        url: "Games/Delete",
        data: { gameId: id },
    success: function (data) {
        if (data.Status == "Success") {
            alert('deleted!');
        } else {
        }
    }
});
}

var gamesMap;

function initializeMap() {
    var centerCoordinateLat = parseFloat($('#Location').attr('data-lat'));
    var centerCoordinateLng = parseFloat($('#Location').attr('data-lng'));
    createMap(centerCoordinateLat, centerCoordinateLng);    
}

function createMap(centerCoordinateLat, centerCoordinateLng) {
    var zoom = 10;

    if ($('#Location').val() == "" || (centerCoordinateLat == 37.09024 && centerCoordinateLng == -95.712891)) {
        zoom = 3;
    }

    gamesMap = new google.maps.Map(document.getElementById('map-canvas'), {
        zoom: zoom,
        center: new google.maps.LatLng(centerCoordinateLat, centerCoordinateLng),
        mapTypeId: google.maps.MapTypeId.ROADMAP
    });

    var marker, i;

    var coordinates = [];
    $('.location').each(function (index) {
        coordinates[index] = [parseFloat($(this).attr('data-lat')), parseFloat($(this).attr('data-lng'))];
    });

    $(coordinates).each(function (index, elem) {
        marker = new google.maps.Marker({
            position: new google.maps.LatLng(elem[0], elem[1]),
            map: gamesMap,
            title: 'time to ball!',
            draggable: true,
            animation: google.maps.Animation.DROP
        });

        google.maps.event.addListener(marker, 'click', (function (marker, i) {
            return function () {
                if (marker.getAnimation() != null) {
                    marker.setAnimation(null);
                } else {
                    marker.setAnimation(google.maps.Animation.BOUNCE);
                }
            }
        })(marker, i));
    });

    var input = (document.getElementById('Location'));
    var autocomplete = new google.maps.places.Autocomplete(input);
    autocomplete.bindTo('bounds', gamesMap);
    google.maps.event.addListener(gamesMap, 'dragend', resetMapCenter);
}

function resetMapCenter() {
    var latlng = gamesMap.getCenter();   
    var geocoder = new google.maps.Geocoder();
    geocoder.geocode({ 'latLng': latlng }, function (results, status) {
        if (status == google.maps.GeocoderStatus.OK) {
            if (results[1]) {
                $('#Location').val(results[1].formatted_address);
                pageGames(1);                
            } else {
                alert('No results found');
            }
        } else {
            alert('Geocoder failed due to: ' + status);
        }
    });
}

function validateLatLng(address) {
    var geocoder = new GClientGeocoder();

    var coordinates = geocoder.getLatLng(address, function (point) {
        var latitude = point.y;
        var longitude = point.x;
    });
}