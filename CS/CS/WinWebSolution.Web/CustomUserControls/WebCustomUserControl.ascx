<%-- BeginRegion TagPrefix and control properties --%>
<%@ Control Language="C#" AutoEventWireup="True" Inherits="WebCustomUserControl" Codebehind="WebCustomUserControl.ascx.cs" %>
<%@ Register Assembly="DevExpress.Web.ASPxEditors.v10.2, Version=10.2.1.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors"  TagPrefix="dxe" %>
<%@ Register Assembly="DevExpress.Web.ASPxGridView.v10.2, Version=10.2.1.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dxwgv" %>
<%@ Register Assembly="DevExpress.Web.v10.2, Version=10.2.1.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxPager" TagPrefix="dxwp" %>
<%-- EndRegion --%>
    <dxwgv:ASPxGridView ID="grid" ClientInstanceName="grid" runat="server" Width="100%" AutoGenerateColumns="True">
        <Settings ShowGroupPanel="True" ShowFilterRow="True" />
    </dxwgv:ASPxGridView>
