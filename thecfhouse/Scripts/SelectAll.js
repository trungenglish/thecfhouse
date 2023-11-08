
    var selectAllButton = document.getElementById("selectAll");
    var deselectAllButton = document.getElementById("deselectAll");
    var checkboxes = document.getElementsByClassName("checkbox");

    selectAllButton.addEventListener("click", function() {
    for (var i = 0; i < checkboxes.length; i++) {
        checkboxes[i].checked = true;
    }
});

    deselectAllButton.addEventListener("click", function() {
    for (var i = 0; i < checkboxes.length; i++) {
        checkboxes[i].checked = false;
    }
});
