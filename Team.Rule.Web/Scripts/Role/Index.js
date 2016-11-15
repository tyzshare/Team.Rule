$(function () {

    Load(1);

    //表单验证
    $("#fr_editRole").validate({

        submitHandler: function () {
            $.post("/role/insertrole", { "Name": $("#txt_RoleName").val() }, function (data) {
                tool.alert(data.message);
                Load(1);
            });
        }
    });
})

//加载
function Load(pageIndex) {
    var colspanNum = $("#pr").parent().find('tr').eq(0).find("td").length;
    $("#pr").html('<tr><td colspan=' + colspanNum + '><center><img src="http://js.xueyiyun.com/common/layer/admin/v1.0/skin/default/loading-2.gif"/></center><td></tr>');
    $("#pr").load("/role/loadrolelist", { "pageIndex": pageIndex }, function () {
    });
}

//删除
function Del(id) {
    layer.confirm("确定要删除", function () {
        debugger
        $.post("/role/deleterole", { "id": id }, function (data) {
            if (data.success) {
                tool.close();
                if (currentPage != 1 && $("#pr").find("tr").length == 1) {
                    Load(currentPage - 1);
                }
                else {
                    Load(currentPage);
                }
            }
            else {
                tool.alert(data.message);
            }
        });
    })
}