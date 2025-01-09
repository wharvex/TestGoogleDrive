
$(document).ready(function () {
    $("#configSelect").change(function () {
        var selectedConfigId = this.value;
        $.ajax({
            url: '/TestRuns/GetConfigPath',
            data: { configId: selectedConfigId },
            success: function (data) {
                console.log(data.configPath);
                $("#configPathDisplay").text(data.configPath);
            }
        });
    });
});
