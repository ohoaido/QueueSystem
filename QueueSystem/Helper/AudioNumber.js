(function () {
    var Mp3Queue = function (container, files) {
        var index = 1;
        if (!container || !container.tagName || container.tagName !== 'AUDIO') throw 'Invalid container';
        if (!files || !files.length) throw 'Invalid files array';

        var playNext = function () {
            if (index < files.length) {
                container.src = files[index];
                index += 1;
            } else {
                container.removeEventListener('ended', playNext, false);
            }
        };

        container.addEventListener('ended', playNext);

        container.src = files[0];
    };
    var container = document.getElementById('container');
    MyFunction = function (id) {
        $('#showManHinh').empty();
        $('#showNext').empty();
        $('#playlist').empty();
        $.ajax({
            type: 'GET',
            url: '/HeThongSos/Show/' + id,
            data: "",
            contentType: 'application/json; charset=utf-8',
            dataType: 'json',
            success: function (msg) {
                if (msg.ID != 99999) {
                    $('#showManHinh').append(
                         msg.STT
                    );
                    $('#showNext').append(
                         '<button class="btn" onclick="Next(' + id + ');return false;">Gọi tiếp</button>'
                         + '<button class="btn" onclick="MyFunction(' + id + ');return false;">Gọi Lại</button>'
                    );
                    StrSplit(msg.STT);
                } else {
                    $('#showManHinh').append(
                         "Đã hết lượt khám"
                    );
                }
            }
        });
    }
    Next = function (id) {
        $('#showManHinh').empty();
        $('#showNext').empty();
        $('#playlist').empty();
        $.ajax({
            type: 'GET',
            url: '/HeThongSos/ShowSo/' + id,
            data: "",
            contentType: 'application/json; charset=utf-8',
            dataType: 'json',
            success: function (msg) {
                if (msg.STT != 0) {
                    $('#showManHinh').append(
                         msg.STT
                    );
                    $('#showNext').append(
                         '<button class="btn" onclick="Next(' + id + ');return false;">Gọi tiếp</button>'
                         + '<button class="btn" onclick="MyFunction(' + id + ');return false;">Gọi Lại</button>'
                    );
                    StrSplit(msg.STT);
                } else {
                    $('#showManHinh').append(
                         "Đã hết lượt khám"
                    );
                }
            }
        });
    };
    function StrSplit(str) {
        $('#playlist').empty();
        var output = [];
        var sNumber = str.toString();
        for (var i = 0, len = sNumber.length; i < len; i += 1) {
            output.push(sNumber[i]);
        }
        var str = ['/lib/Voice_mp3/m1.mp3', '/lib/Voice_mp3/m3.mp3'];
        var j = 0;
        output.forEach(function (value) {
            if ((3 > output.length && output.length > 1 && value == 1 && j == 0) || (4 > output.length && output.length > 2 && value == 1 && j == 1)) {
                str.push('/lib/Voice_mp3/sb.mp3');
                j++;
            }
            else {
                switch (value) {
                    case "0":
                        if (output.length == 2 && j == 0) {
                            str.push('/lib/Voice_mp3/sc.mp3');
                            j++;
                        }
                        break;
                    case "1":
                        str.push('/lib/Voice_mp3/s1.mp3');
                        break;
                    case "2":
                        str.push('/lib/Voice_mp3/s2.mp3');
                        break;
                    case "3":
                        str.push('/lib/Voice_mp3/s3.mp3');
                        break;
                    case "4":
                        str.push('/lib/Voice_mp3/s4.mp3');
                        break;
                    case "5":
                        str.push('/lib/Voice_mp3/s5.mp3');
                        break;
                    case "6":
                        str.push('/lib/Voice_mp3/s6.mp3');
                        break;
                    case "7":
                        str.push('/lib/Voice_mp3/s7.mp3');
                        break;
                    case "8":
                        str.push('/lib/Voice_mp3/s8.mp3');
                        break;
                    case "9":
                        str.push('/lib/Voice_mp3/s9.mp3');
                        break;
                }
            }
        });
        new Mp3Queue(container, str);
    }
})();