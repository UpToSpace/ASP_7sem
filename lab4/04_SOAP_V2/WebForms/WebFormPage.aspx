<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebFormPage.aspx.cs" Inherits="_04_SOAP_V2.WebForms.WebFormPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>webform</title>
<script src="../Scripts/jquery-3.4.1.js"></script>
    <script>
        function getSum_Ajax() {
            const data = {
                x: parseInt($("#x").val()),
                y: parseInt($("#y").val())
            };
            const json = JSON.stringify(data);
            $.ajax({
                url: "../Services/Simplex.asmx/addS",
                type: "POST",
                dataType: "json",
                contentType: "application/json; charset=utf-8",
                data: json,
                success: result => {
                    $("#result").val(result.d);
                },
                error: error => {
                    console.log(error);
                }
            })
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div>
                <input type="text" id="x"/>
                <input type="text" id="y"/>
                <input type="button" onclick="getSum_Ajax()" value="ajax" />
            </div>
            <div>
                <input type="text" id="result"/>
            </div>
        </div>
    </form>
</body>
</html>

