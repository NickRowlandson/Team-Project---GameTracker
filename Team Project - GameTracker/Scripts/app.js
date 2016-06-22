/* Custom JS */

$(document).ready(function () {
    console.log("App started...");
    $(".delete").click(function () {
        return confirm("Are you sure you want to delete this record?");
    })
})
