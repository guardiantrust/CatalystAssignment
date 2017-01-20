function searchPerson() {
    var search = $('.searchText').val();

    $.ajax({
        url: 'SearchPerson?search=' + search,
        type: 'GET',
        success: function (data) {

        }
    });
}