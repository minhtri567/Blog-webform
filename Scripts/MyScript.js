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
    },
    searchPosts: function() {
        const query = document.getElementById('searchQuery').value.trim();
        if (query) {
            const baseUrl = window.location.origin; // Lấy gốc của URL
            window.location.href = baseUrl + '/SearchResults?q=' + encodeURIComponent(query);
        } else {
            alert('Vui lòng nhập từ khóa tìm kiếm!');
        }
    },
    handleEnter: function (event) {
        if (event.key === 'Enter') { // Kiểm tra phím Enter
            event.preventDefault(); // Ngăn không submit form mặc định
            this.searchPosts();     // Gọi hàm searchPosts
        }
    }
}
