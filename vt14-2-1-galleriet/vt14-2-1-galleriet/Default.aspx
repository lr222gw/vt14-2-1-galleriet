<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="vt14_2_1_galleriet.Default" ViewStateMode="Disabled" %>

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
            <asp:Image ID="ImageHolder" runat="server"  ImageUrl="~\pics\bg.jpg"/>
        </div>
        <div id="thumbnailBox">

            <asp:Repeater ID="Repeater2" runat="server" ItemType="System.IO.FileInfo" SelectMethod="Repeater2_GetData">
                <ItemTemplate>
                    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%#: "Default.aspx?" + Server.UrlEncode(Item.Name)  %>'>
                        <asp:Image runat="server"  ImageUrl='<%#  @"~\pics\thumbnails\" + Item.Name  %>' />
                    </asp:HyperLink>
                </ItemTemplate>
            </asp:Repeater>

        </div>
        <div id="uploadBox">
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" />
            <asp:FileUpload ID="GalleryFileUploader" runat="server"  />
            <asp:Button ID="uploadButton" runat="server" Text="Upload" OnClick="uploadButton_Click"   />
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Fil måste väljas" ControlToValidate="GalleryFileUploader" Display="Dynamic">*</asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Rätt filtyp måste väljas (JPG, PNG, GIF)" Text="*" ControlToValidate="GalleryFileUploader" Display="Dynamic" ValidationExpression="^.*\.(gif|jpg|png)$">*</asp:RegularExpressionValidator>
        </div>
    </div>
    </form>
    <%-- ↓ Här kommer javascripten ↓--%>
    <script type="text/javascript" src="Scripts/Script.js"></script>
</body>
</html>
