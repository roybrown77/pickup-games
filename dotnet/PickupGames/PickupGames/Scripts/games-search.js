$(document).ready(function () {
    $('#pagination').pagination({
        items: 100,
        itemsOnPage: 10,
        cssStyle: 'light-theme'/*,
        hrefTextPrefix: '/Games/Search/' + $('#Location').val() + '?page=',
        hrefTextSuffix: getUrlSearchParameters(),*/
    });
});

function onSearchGamesBegin() {
    
}
  
function onSearchGamesComplete() {
    updateUrl();    
}

function onSearchGamesSuccess(data, status, xhr) {
    if (data.Status == "Success") {
        updateGameList(data.Games);
        createMap(data.SearchLocationLat, data.SearchLocationLng);
    } else {
        alert(data.Message);
    }
}

function pageGames(index) {
    alert(index);
}

function showHideGameSearchFilter() {
    $('#searchgames').toggle(500);
};

function updateUrl() {
    var urlSearchParameterArray = getUrlSearchParameterArray();

    if (urlSearchParameterArray.length > 0) {
        window.history.pushState("searchcriteria", "searchcriteria", "?" + urlSearchParameterArray.join("&"));
    }
}

function getUrlSearchParameterString() {    
    var urlSearchParameterString = '';
    var urlSearchParameterArray = getUrlSearchParameterArray();

    if (urlSearchParameterArray.length > 0) {
        urlSearchParameterString = '&' + urlSearchParameterArray.join("&");
    }
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

function initializeMap() {
    var centerCoordinateLat = parseFloat($('#Location').attr('data-lat'));
    var centerCoordinateLng = parseFloat($('#Location').attr('data-lng'));
    createMap(centerCoordinateLat, centerCoordinateLng);
}

function createMap(centerCoordinateLat, centerCoordinateLng) {
    var zoom = 10;

    if ($('#Location').val() == "") {
        zoom = 3;
    }

    var map = new google.maps.Map(document.getElementById('map-canvas'), {
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
            map: map,
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
    autocomplete.bindTo('bounds', map);
}

function validateLatLng(address) {
    var geocoder = new GClientGeocoder();

    var coordinates = geocoder.getLatLng(address, function (point) {
        var latitude = point.y;
        var longitude = point.x;
    });
}

google.maps.event.addDomListener(window, 'load', initializeMap);