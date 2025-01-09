
$(document).ready(function () {
    $("#configSelect").change(function () {
        var selectedConfigId = this.value;
        $.ajax({
            url: '/TestRuns/GetConfigPath',
            data: { configId: selectedConfigId },
            success: function (data) {
                console.log(data.configPath);
                console.log(data.configPathId);
                $("#configPathDisplay").text(data.configPath);
            }
        });
    });
});
