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
    }
}
