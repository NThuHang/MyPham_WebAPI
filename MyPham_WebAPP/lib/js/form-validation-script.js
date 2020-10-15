var Script = function () {

    $.validator.setDefaults({
        submitHandler: function() { alert("submitted!"); }
    });

    $().ready(function() {
        // validate the comment form when it is submitted
        $("#commentForm").validate();

        // validate signup form on keyup and submit
        $("#signupForm").validate({
            rules: {
                hoten: "required",
                sdt: "required",
                matkhau: {
                    required: true,
                    minlength: 5
                },
                nhaplai_matkhau: {
                    required: true,
                    minlength: 5,
                    equalTo: "#matkhau"
                },
                email: {
                    required: true,
                    email: true
                },
                topic: {
                    required: "#newsletter:checked",
                    minlength: 2
                },
                diachi: "required"
            },
            messages: {
                hoten: "Bạn Hãy Nhập Họ Và Tên",
                sdt: "Bạn Hãy Nhập Họ Và Tên",
                matkhau: {
                    required: "Bạn Hãy Nhập Mật Khẩu",
                    minlength: "Mật Khẩu của bạn phải dài ít nhất 5 ký tự"
                },
                nhaplai_matkhau: {
                    required: "Bạn Hãy Nhập Mật Khẩu",
                    minlength: "Mật Khẩu của bạn phải dài ít nhất 5 ký tự",
                    equalTo: "Mật Khẩu Không Khớp.Vui lòng nhập mật Khẩu như trên"
                },
                email: "Vui Lòng Nhập Địa Chỉ email",
                diachi: "Vui Lòng Nhập Địa Chỉ Của Bạn"
            }
        });

        

        //code to hide topic selection, disable for demo
        var newsletter = $("#newsletter");
        // newsletter topics are optional, hide at first
        var inital = newsletter.is(":checked");
        var topics = $("#newsletter_topics")[inital ? "removeClass" : "addClass"]("gray");
        var topicInputs = topics.find("input").attr("disabled", !inital);
        // show when newsletter is checked
        newsletter.click(function() {
            topics[this.checked ? "removeClass" : "addClass"]("gray");
            topicInputs.attr("disabled", !this.checked);
        });
    });


}();