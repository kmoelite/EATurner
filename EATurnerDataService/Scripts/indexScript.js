function searchByActor() {
    $('#criteriaButton').html('<b style="color:red">Actors</b>');
}

function searchByTitle() {
    $('#criteriaButton').html('<b style="color:red">Title</b>');
}

function searchByGenre() {
    $('#criteriaButton').html('<b style="color:red">Genres</b>');
}

function searchByAward() {
    $('#criteriaButton').html('<b style="color:red">Awards</b>');
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
    $('#loadingDiv').show()
    $.ajax({
        type: "POST",
        url: "/Home/GetMovie/",
        data: { movieSearchText : $('#universalTextBox').val() },
    }).success(function (result) {
        $('#loadingDiv').hide()
        console.log(result);
        $('#searchByTitleResultDiv').html(result);
        $('#searchByTitleResultDiv').show();
    }).error(function (result) {
        console.log(result);
        alert('An unexpected error has occurred. Please try again.');
        location.reload();
        });
}

function loadDetailsView(id) {
    $('#loadingDiv').show();
    $('#searchByTitleResultDiv').hide();
    $.ajax({
        type: "POST",
        url: "/Home/GetMovieDetails/",
        data: { titleId: id },
    }).success(function (result) {
        $('#loadingDiv').hide()
        console.log(result);
        $('#detailedMediaResultsDivResult').html(result);
        $('#detailedMediaResultsDivResult').show();
        $('#SearchByDropDownDiv').show();
    }).error(function (result) {
        console.log(result);
        //alert('An unexpected error has occurred. Please try again.');
        //location.reload();
    });}