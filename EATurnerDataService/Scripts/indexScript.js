function searchByActor() {
    $('#criteriaButton').html('<b style="color:red">Actors</b>');
    hideAllFilteredDivs();
    $('#detailedResultsCast').show();
}

function searchByMisc() {
    $('#criteriaButton').html('<b style="color:red">Miscellaneous</b>');
    hideAllFilteredDivs();
    $('#detailedResultsOtherInfo').show();
}

function searchByGenre() {
    $('#criteriaButton').html('<b style="color:red">Genres</b>');
    hideAllFilteredDivs();
    $('#detailedResultsGenres').show();
}

function searchByAward() {
    $('#criteriaButton').html('<b style="color:red">Awards</b>');
    hideAllFilteredDivs();
    $('#detailedResultsAwards').show();
}

function searchBySynopsis() {
    $('#criteriaButton').html('<b style="color:red">Synopsis</b>');
    hideAllFilteredDivs();
    $('#detailedResultsSynopsis').show();
}

function showMeEverything() {
    $('#criteriaButton').html('<b style="color:red">Everything</b>');
    showAllFilteredDivs();
}

function hideAllFilteredDivs()
{
    $('#detailedResultsSynopsis').hide();
    $('#detailedResultsGenres').hide();
    $('#detailedResultsAwards').hide();
    $('#detailedResultsCast').hide();
    $('#detailedResultsOtherInfo').hide();
}

function showAllFilteredDivs() {
    $('#detailedResultsSynopsis').show();
    $('#detailedResultsGenres').show();
    $('#detailedResultsAwards').show();
    $('#detailedResultsCast').show();
    $('#detailedResultsOtherInfo').show();
}

function sanitizeInput(searchText)
{
    var returnText = searchText.Trim();
    //could do other cleanup later on
    return returnText;
}

$("#universalTextBox").keyup(function (event) {
    if (event.keyCode === 13) {
        $("#submitSearchQueryButton").click();
    }
});

function submitTextSearch() {
    $('#loadingDiv').show();
    $('#SearchByDropDownDiv').hide();
    $('#detailedMediaResultsDivResult').hide();
    $('#searchByTitleResultDiv').hide();
    $.ajax({
        type: "POST",
        url: "/Home/GetMovie/",
        data: { movieSearchText : $('#universalTextBox').val() },
    }).success(function (result) {
        $('#loadingDiv').hide();
        $('#searchByTitleResultDiv').html(result);
        $('#searchByTitleResultDiv').show();
    }).error(function (result) {
        alert('An unexpected error has occurred. Please try again.');
        location.reload();
        });
}

function loadDetailsView(id) {
    $('#loadingDiv').show();
    $('#SearchByDropDownDiv').hide();
    $('#detailedMediaResultsDivResult').hide();
    $('#searchByTitleResultDiv').hide();
    $.ajax({
        type: "POST",
        url: "/Home/GetMovieDetails/",
        data: { titleId: id },
    }).success(function (result) {
        $('#loadingDiv').hide();
        $('#detailedMediaResultsDivResult').html(result);
        $('#detailedMediaResultsDivResult').show();
        $('#SearchByDropDownDiv').show();
        $('#universalTextBox').val($('#movieSelected').text());
        }).error(function (result) {
            alert('failure');
        alert('An unexpected error has occurred. Please try again.');
        location.reload();
    });}