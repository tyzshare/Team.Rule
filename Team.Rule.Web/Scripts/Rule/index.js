$(function () {

    Load(1);

    //表单验证
    $("#fr_editRule").validate({
        rules: {
            RuleName: { rangelength: [1,8] },
            RuleDetail: { maxlength: 100 },
        },
        messages: {
            RuleName: { rangelength: "请输入[1-8]个字符" },
            RuleDetail: { maxlength: "规则内容不能大于100个字符" },
        },

        submitHandler: function () {
            $.post("/rule/createruleasync", { "RuleName": $("#txt_RuleName").val(), "RuleDetail": $("#txt_RuleDetail").val() }, function (data) {
                //layer.msg(data.message);
                _alert(data.message)
                Load(1);
                //if (data.IsSuccess) {
                //    layer.msg(data.Message);
                //    Load(1);
                //}
                //else {
                //    layer.msg(data.Message);
                //}
            });
        }
    });
})

//加载
function Load(pageIndex) {
    var colspanNum = $("#pr").parent().find('tr').eq(0).find("td").length;
    $("#pr").html('<tr><td colspan=' + colspanNum + '><center><img src="http://js.xueyiyun.com/common/layer/admin/v1.0/skin/default/loading-2.gif"/></center><td></tr>');
    $("#pr").load("/rule/LoadRuleList", { "pageIndex": pageIndex }, function () {
        //var html = '@Html.Raw(Html.Pager(Model.pi.PageSize, Model.pi.PageIndex, Model.pi.ItemCount, new { }, true, "Load"))';
        //$(".page-div").html(html);
    });
}

//删除
function Del(id) {
    layer.confirm("确定要删除", function () {
        $.post("/rule/DeleteRule", { "id": id }, function (data) {
            if (data.success) {
                _close();
                if (currentPage != 1 && $("#pr").find("tr").length == 1) {
                    Load(currentPage - 1);
                }
                else {
                    Load(currentPage);
                }
            }
            else {
                _alert(data.message);
            }
        });
    })
}