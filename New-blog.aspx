<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="New-blog.aspx.cs" Inherits="BTLBlog.new_blog" ValidateRequest="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Panel ID="pnlCreateBlog" CssClass="container-newblog" runat="server">
        <h2>Tạo bài viết mới</h2>
        <div class="container-input">
            <label class="form-text">Tiêu đề bài viết:</label>
            <asp:TextBox ID="txtBlogTitle" runat="server" CssClass="form-control" />
        </div>
        <div class="container-input">
            <label class="form-text">Hình ảnh tiêu đề:</label>
            <asp:FileUpload ID="fileBlogTitleImg" runat="server" CssClass="form-control file-upload" />
            <div id="container-imgPreview" style="display:none;"">
                <div class="popover-arrow" style="position: absolute; left: 0px; transform: translate(66px, 0px);"></div>
                <div class="popover-content">
                    <img id="imgPreview" src="#" alt="Preview Image" class="img-preview" />
                </div>
            </div>
       </div>

        <div class="container-input">
            <label class="form-text">Danh mục:</label>
            <asp:ListBox ID="ddlBlogDanhmuc" runat="server" CssClass="selectize" SelectionMode="Multiple">
            </asp:ListBox>
        </div>

        <div class="ckeditor" >
            <label class="form-text">Tóm tắt bài viết:</label>
            <asp:TextBox ID="txtsumaruct" CssClass="form-control" TextMode="MultiLine" runat="server" />
        </div>

        <div class="ckeditor" >
            <label class="form-text">Nội dung bài viết:</label>
            <asp:TextBox ID="txtBlogContent" TextMode="MultiLine" runat="server" />
        </div>
        <br />

        <asp:Button ID="btnSaveBlog" runat="server" Text="Lưu bài viết" OnClick="btnLuu_Click" CssClass="btn btn-primary" />
    </asp:Panel>
    <script src="/Scripts/jquery/jquery.min.js"></script>
    <script src="/Scripts/ckeditor/ckeditor.js"></script>
    <script src="/Content/selectize/js/selectize.min.js" crossorigin="anonymous" referrerpolicy="no-referrer"></script>
    <script>

        const fileInput = document.getElementById('<%= fileBlogTitleImg.ClientID %>');
        const imgPreview = document.getElementById('imgPreview');
        const ctimgPreview = document.getElementById('container-imgPreview');

        fileInput.addEventListener('mouseenter', function () {
            if (fileInput.files.length > 0) {
                const file = fileInput.files[0];
                const reader = new FileReader();

                reader.onload = function (e) {
                    imgPreview.src = e.target.result;
                    ctimgPreview.style.display = 'block'; // Hiển thị hình ảnh
                };

                reader.readAsDataURL(file);
            }
        });

        // Ẩn hình ảnh khi rời khỏi input file
        fileInput.addEventListener('mouseleave', function () {
            ctimgPreview.style.display = 'none'; // Ẩn hình ảnh
        });

        $('#MainContent_ddlBlogDanhmuc').selectize({ sortField: 'text' });
        CKEDITOR.ClassicEditor.create(document.getElementById('MainContent_txtBlogContent'), {
                toolbar: {
                    items: [
                        'exportPDF', 'exportWord', '|',
                        'findAndReplace', 'selectAll', '|',
                        'heading', '|',
                        'bold', 'italic', 'strikethrough', 'underline', 'code', 'subscript', 'superscript', 'removeFormat', '|',
                        'bulletedList', 'numberedList', 'todoList', '|',
                        'outdent', 'indent', '|',
                        'undo', 'redo',
                        '-',
                        'fontSize', 'fontFamily', 'fontColor', 'fontBackgroundColor', 'highlight', '|',
                        'alignment', '|',
                        'link', 'uploadImage', 'blockQuote', 'insertTable', 'mediaEmbed', 'codeBlock', 'htmlEmbed', '|',
                        'specialCharacters', 'horizontalLine', 'pageBreak', '|',
                    ],
                    shouldNotGroupWhenFull: true
                },
                list: {
                    properties: {
                        styles: true,
                        startIndex: true,
                        reversed: true
                    }
                },
                ckfinder: {
                    uploadUrl: '/UploadHandler.ashx'  // Đường dẫn tới API tải ảnh
                },
                heading: {
                    options: [
                        { model: 'paragraph', title: 'Paragraph', class: 'ck-heading_paragraph' },
                        { model: 'heading1', view: 'h1', title: 'Heading 1', class: 'ck-heading_heading1' },
                        { model: 'heading2', view: 'h2', title: 'Heading 2', class: 'ck-heading_heading2' },
                        { model: 'heading3', view: 'h3', title: 'Heading 3', class: 'ck-heading_heading3' },
                        { model: 'heading4', view: 'h4', title: 'Heading 4', class: 'ck-heading_heading4' },
                        { model: 'heading5', view: 'h5', title: 'Heading 5', class: 'ck-heading_heading5' },
                        { model: 'heading6', view: 'h6', title: 'Heading 6', class: 'ck-heading_heading6' }
                    ]
                },
                placeholder: 'Nhập nội dung bài viết',
                fontFamily: {
                    options: [
                        'default',
                        'Arial, Helvetica, sans-serif',
                        'Courier New, Courier, monospace',
                        'Georgia, serif',
                        'Lucida Sans Unicode, Lucida Grande, sans-serif',
                        'Tahoma, Geneva, sans-serif',
                        'Times New Roman, Times, serif',
                        'Trebuchet MS, Helvetica, sans-serif',
                        'Verdana, Geneva, sans-serif'
                    ],
                    supportAllValues: true
                },
                fontSize: {
                    options: [10, 12, 14, 'default', 18, 20, 22],
                    supportAllValues: true
                },
                htmlSupport: {
                    allow: [
                        {
                            name: /.*/,
                            attributes: true,
                            classes: true,
                            styles: true
                        }
                    ]
                },
                htmlEmbed: {
                    showPreviews: false
                },
                link: {
                    decorators: {
                        addTargetToExternalLinks: true,
                        defaultProtocol: 'https://',
                        toggleDownloadable: {
                            mode: 'manual',
                            label: 'Downloadable',
                            attributes: {
                                download: 'file'
                            }
                        }
                    }
                },
                mention: {
                    feeds: [
                        {
                            marker: '@',
                            feed: [
                                '@apple', '@bears', '@brownie', '@cake', '@cake', '@candy', '@canes', '@chocolate', '@cookie', '@cotton', '@cream',
                                '@cupcake', '@danish', '@donut', '@dragée', '@fruitcake', '@gingerbread', '@gummi', '@ice', '@jelly-o',
                                '@liquorice', '@macaroon', '@marzipan', '@oat', '@pie', '@plum', '@pudding', '@sesame', '@snaps', '@soufflé',
                                '@sugar', '@sweet', '@topping', '@wafer'
                            ],
                            minimumCharacters: 1
                        }
                    ]
                },
                removePlugins: [
                    'AIAssistant',
                    'CKBox',
                    'CKFinder',
                    'EasyImage',
                    'MultiLevelList',
                    'RealTimeCollaborativeComments',
                    'RealTimeCollaborativeTrackChanges',
                    'RealTimeCollaborativeRevisionHistory',
                    'PresenceList',
                    'Comments',
                    'TrackChanges',
                    'TrackChangesData',
                    'RevisionHistory',
                    'Pagination',
                    'WProofreader',
                    'MathType',
                    'SlashCommand',
                    'Template',
                    'DocumentOutline',
                    'FormatPainter',
                    'TableOfContents',
                    'PasteFromOfficeEnhanced',
                    'CaseChange'
                ]
            })
            .catch(error => {
                console.error(error);
            });

        document.querySelector('form').onsubmit = function () {
            document.querySelector('#MainContent_txtBlogContent').value = editor.getData();
        };
    </script>
</asp:Content>
