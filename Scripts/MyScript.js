const Custom = {
    Mytoast: function (content, imgUrl) {
        const toastLiveExample = document.getElementById('liveToast');

        if (toastLiveExample) {
            // Cập nhật nội dung và hình ảnh cho toast
            document.getElementById("toastBody").innerText = content;
            document.getElementById("toastImage").src = imgUrl;

            // Tạo hoặc lấy toast instance và hiển thị nó
            const toastBootstrap = bootstrap.Toast.getOrCreateInstance(toastLiveExample);
            toastBootstrap.show();
        }
    },
    displaySelectedImage: function (event, imgId) {
        const file = event.target.files[0];
        if (file) {
            const reader = new FileReader();
            reader.onload = function (e) {
                document.getElementById(imgId).src = e.target.result;
            };
            reader.readAsDataURL(file); // Đọc file
        }
    }
}
