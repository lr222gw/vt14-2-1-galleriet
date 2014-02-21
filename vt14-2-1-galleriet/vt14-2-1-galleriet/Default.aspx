<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="vt14_2_1_galleriet.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Galleriet</title>
    <meta charset="utf-8" />
    <link rel="stylesheet" href="Css/style.css" />
</head>
<body>
    <form id="form1" runat="server">
    <div id="gallery">
        <div id="imageBox">
            <asp:Repeater ID="Repeater1" runat="server"></asp:Repeater>
        </div>
        <div id="thumbnailBox">
            <asp:ListView ID="ListView1" runat="server">
                <ItemTemplate>

                </ItemTemplate>
            </asp:ListView>
        </div>
        <div id="uploadBox">
            <asp:FileUpload ID="GalleryFileUploader" runat="server"  />
            <asp:Button ID="uploadButton" runat="server" Text="Upload" />
        </div>
    </div>
    </form>
    <%-- ↓ Här kommer javascripten ↓--%>
    <script type="text/javascript" src="Scripts/Script.js"></script>
</body>
</html>
