$(document).ready(function () {
    var playerInfo = {
        PlayerId: null,
        TeamId: null
    };
    $("#assignPlayer").submit(function (event) {
        event.preventDefault();
        playerInfo.PlayerId = parseInt($("#Players").val());
        playerInfo.TeamId = parseInt($("#teamId").val());
        $.ajax({
            url: '/Teams/Assign',
            type: "POST",
            dataType: 'json',
            data: playerInfo,
            success: function (result) {
                console.log(result);
                $("#playerTable").append('<tr><td><a href="/Players/Details/' + result.id + '">' + result.name + '</a></td><td>' + result.position + '</td><td>' + result.fantasyPoints + '</td></tr>');
            },
            error: function (e) {
                console.log(e);
            },

        });
    });
});