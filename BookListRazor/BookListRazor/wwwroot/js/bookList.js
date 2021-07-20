var dayaTable;

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#DT_Load').DataTable({
        "ajax": {
            "url": "/api/book",
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "name", "widht": "30%" },
            { "data": "author", "widht": "30%" },
            { "data": "isbn", "widht": "30%" },
            {
                "data": "id",
                "render": function(data) {
                    return `
                        <div class="text-center">
                            <a href="/BookList/Upsert?id=${data}" class="btn btn-success text-white" style="cursor: pointer; width: 100px;">Edit</a>
                            &nbsp;
                            <a onclick=Delete('api/book?id=${data}') class="btn btn-danger text-white" style="cursor: pointer; width: 100px;">Delete</a>
                        </div>
                    `

                },
                "width": "30%"
            }
        ],
        "language": {
            "emptyTable": "No data found"
        },
        "width": "100%"
    });
}

function Delete (url) {
    swal({
        title: "Are you sure?",
        text: "Once deleted, you will not be able to recover",
        icon: "warning",
        buttons: true,
        dangerMode: true
    }).then(willDelete => {
        if (willDelete) {
            $.ajax({
                type: "DELETE",
                url: url,
                success: function (data) {
                    if (data.success) {
                        toastr.success(data.message);
                        dataTable.ajax.reload();
                    } else {
                        toastr.error(data.message);
                    }
                }
            });
        }
    });
}