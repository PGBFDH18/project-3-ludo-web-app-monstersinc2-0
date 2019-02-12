function GetPlayerName(gameID) {
    var request = new XMLHttpRequest();
    var api = 'https://localhost:44365/api/ludo/' + gameID + '/player/current';

    request.open('GET', api, true);

    request.onload = function () {
        var data = JSON.parse(this.response);
        data.forEach(player => {
            console.log(player.name);
        })
    }
}