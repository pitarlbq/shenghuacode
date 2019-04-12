function do_export() {
    top.$.messager.confirm('提示', '确认导出?', function (r) {
        if (r) {
            var options = get_options();
            var url = options.url || '../Handler/AnalysisHandler.ashx';
            options.canexport = true;
            options.page = 1;
            options.rows = 10;
            top.MaskUtil.mask('body', '下载中');
            $.ajax({
                type: 'POST',
                dataType: 'json',
                url: url,
                data: options,
                success: function (data) {
                    top.MaskUtil.unmask();
                    if (data.status) {
                        setTimeout(function () {
                            window.location.href = data.downloadurl;
                        }, 1000)
                        return;
                    }
                    if (data.error) {
                        show_message(data.error, 'warning');
                        return;
                    }
                    show_message('系统异常', 'error');
                }
            });
        }
    })
}
