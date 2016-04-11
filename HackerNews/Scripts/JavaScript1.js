$(function () {
    $(".vote").on('click', function () {
        var linkId = $(this).data('id');
        var amountOfPoints = $(this).closest("tr").find("td:eq(2)");
        debugger;
        $.post("/home/upvote", { linkId: linkId }, function (upvoteAmountUnique) {
            amountOfPoints.html(upvoteAmountUnique.UpvoteAmount);
            if(upvoteAmountUnique.NotUnique)
            {
                alert("Sorry You Already Upvoted That!");
            }
        })
        $(".vote").prop('disabled', true);
    })
});