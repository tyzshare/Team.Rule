$(function () {

    Load(1);

    //表单验证
    $("#fr_editUser").validate({

        /*2：将校验规则写到控件中，把提示信息自定义写在js中*/
        //rules: {
        //},
        //messages: {
        //    LoginEmail: { required: "登陆邮箱不能为空", email: "请输入有效邮箱", maxlength: "登录邮箱不能大于20个字符" },
        //    LoginPwd: { required: "登陆密码不能为空", rangelength: "密码长度8-16位，建议大小写，特殊字符拼写" },
        //},

        /*3：将校验规则，提示信息都写到js中*/
        //rules: {
        //    LoginEmail: { email: true },
        //    LoginPwd: { rangelength: [8, 16] },
        //},
        //messages: {
        //    LoginEmail: { email: "请输入有效邮箱" },
        //    LoginPwd: { rangelength: "密码长度8-16位，建议大小写，特殊字符拼写" },  
        //},

        submitHandler: function () {
            debugger
            $.post("/usermanage/insertuserinfo", { "LoginEmail": $("#txt_LoginEmail").val(), "LoginPwd": $("#txt_LoginPwd").val() }, function (data) {
                debugger
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
    $("#pr").load("/usermanage/loaduserinfolist", { "pageIndex": pageIndex }, function () {
        //var html = '@Html.Raw(Html.Pager(Model.pi.PageSize, Model.pi.PageIndex, Model.pi.ItemCount, new { }, true, "Load"))';
        //$(".page-div").html(html);
    });
}

//删除
function Del(id) {
    layer.confirm("确定要删除", function () {
        debugger
        $.post("/usermanage/deleteuserinfo", { "id": id }, function (data) {
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