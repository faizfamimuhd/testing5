// Call the dataTables jQuery plugin

$ $(document).ready(function () {

    $("#whatsappTable").dataTables(
        {
            "ajax": {
                "url": "/Table/GetList",
                "type": "GET",
                "datatype": "json"
            },
            "columns": [
                { "data": "RefNo" },
                { "data": "Pengadu" },
                { "data": "AduanWhatsapp" },
                { "data": "Tindakan" },
                { "data": "Jenis_Aduan" }
            ]

        });
});