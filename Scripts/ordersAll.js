


$(document).ready(function () {

    function notify() {
        alert("clicked");
    }

    //alert(appBaseUrl);

    var loggedUserId = $('#appCurrentUserId').val();
    var loggedUserRole = $('#appCurrentUserRole').val();

    //alert(loggedUserId);
    //alert(loggedUserRole);


    var apiUrl = "";

    apiUrl = appBaseUrl + "apiorder/allorder";

    ////alert(localStorage.getItem("selectedprodlist"));

    var data = {
        "userRole": loggedUserRole,
        "UserId": loggedUserId,
        "pageNumber": "1",
        "Status": ""
        //"City": $('#optCustCity').val(),
        //"Address1": $('#txtRCustBlock').val(),
        //"Address2": $('#txtRCustStreet').val(),
        //"Address3": $('#txtRCustBuilding').val(),
        //"Email": "",
        //"SelectedItem": $('#hdnSelectedItem').val(),
        //"AddressType": $(".delivery-place.active").attr("addresstype"),
        //"SelectedProd": localStorage.getItem("selectedprodlist"),
        //"Note": $('#txtRCustNote').val()
    };

    $('#pagingli').on('click', '.pgli', function () {
        bindData($(this).attr("pageNumber"), "all", "#allitemtbody", "#pagingli");
    });

    $('#pendpagingli').on('click', '.pgli', function () {
        bindData($(this).attr("pageNumber"), "pending", "#pendingitemtbody", "#pendpagingli");
    });

    $('#cancelledpagingli').on('click', '.pgli', function () {
        bindData($(this).attr("pageNumber"), "cancelled", "#cancelleditembody", "#cancelledpagingli");
    });

    $('#completedpagingli').on('click', '.pgli', function () {
        bindData($(this).attr("pageNumber"), "completed", "#completeditembody", "#completedpagingli");
    });

    $('#acceptedpagingli').on('click', '.pgli', function () {
        bindData($(this).attr("pageNumber"), "accepted", "#accepteditembody", "#acceptedpagingli");
    });

    $('#allitemtbody').on('click', '.dataRow1', function () {
        orderDetail(this);
    });

    $('#pendingitemtbody').on('click', '.dataRow1', function () {
        orderDetail(this);
    });

    $('#cancelleditembody').on('click', '.dataRow1', function () {
        orderDetail(this);
    });

    $('#completeditembody').on('click', '.dataRow1', function () {
        orderDetail(this);
    });

    $('#accepteditembody').on('click', '.dataRow1', function () {
        orderDetail(this);
    });

    function orderDetail(objdet) {

        console.log(objdet);

        var oId = $(objdet).attr("orderid");

        $.ajax({
            type: "GET",
            url: appBaseUrl + "/apiorder/getbyid/" + oId,
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (response) {

                

                $("#printDiv").show();

                $('#btnReceiptPrint').attr('productid', oId);

                var orderInfo = JSON.parse(response);
                var delivery = orderInfo.delivery;
                console.log(orderInfo);
                var totalAmount = "";

                console.log(orderInfo);
                $("#divorderItem").empty();

                $("#divorderItem").append("<h5 class='mb - 4'> Items</h5 ><hr/>");
                $.each(orderInfo.orderItems, function (index, orderItm) {
                    console.log(orderItm.OrderId)

                    totalAmount = orderItm.TotalAmount;

                    var divData = "<div class='d-flex justify-content-between my-2 pb-3 border-bottom'> <div><strong>" + orderItm.Item + "</strong></div><div><strong>" + orderItm.Amount + "</strong></div>";
                    $("#divorderItem").append(divData);

                });

                $("#divOrderTotal").empty();
                $('#divOrderTotal').append("<div><strong>Total</strong></div>   <div><strong>KWD " + totalAmount + "</strong></div>");


                $("#divDelAddr").empty();
                $('#divDelAddr').append(delivery.Address);


                $("#divDelContact").empty();
                $("#divDelContact").append("<div> " + delivery.ContactNumber + "</div><div></div>");


                $('#divorderItem').show();
                $('#divOrderTotal').show();
                $('#divDelivery').show();

            },
            failure: function (response) {
                alert(response.responseText);
                alert("Failure");
            },
            error: function (response) {
                alert(response);
                alert("Error");
            }
        });
    }

    bindData(1, "all", "#allitemtbody", "#pagingli");

    bindData(1, "pending", "#pendingitemtbody", "#pendpagingli");

    bindData(1, "cancelled", "#cancelleditembody", "#cancelledpagingli");

    bindData(1, "completed", "#completeditembody", "#completedpagingli");

    bindData(1, "accepted", "#accepteditembody", "#acceptedpagingli");


    function bindData(pgNm, sts, tbody, pagingli) {

        $(tbody).empty();
        $(pagingli).empty();

        data = {
            "pageNumber": pgNm,
            "Status": sts,
            "userRole": loggedUserRole,
            "UserId": loggedUserId
        };

        $.ajax({
            type: "POST",
            url: apiUrl,
            data: JSON.stringify(data),// now data come in this function
            contentType: "application/json; charset=utf-8",
            crossDomain: true,
            dataType: "json",
            success: function (data, status, jqXHR) {

                var pageNumber = 0;
                var rowsOfPage = 0;
                var totalRows = 0;

                //console.log("allorders");
                console.log(data);

                var allItemData = JSON.parse(data)

                

                if (allItemData.length > 0) {



                    $(allItemData).each(function () {

                        totalRows = (this).totalRows;
                        rowsOfPage = (this).rowsOfPage;
                        pageNumber = (this).pageNumber;

                        var tr = "<tr class='dataRow1' orderid='" + (this).OrderId + "'>";
                        var td1 = "<td class='w-30'><div class='ms-4'><p class='text-xs font-weight-bold mb-0'>" + (this).EntryDate + "</p><h6 class='text-sm mb-0 text-danger'>" + (this).EntryTime + "</h6></div></td>";
                        var td2 = "<td><div class='text-center1'><p class='text-xs font-weight-bold mb-0'>#" + (this).OrderNumber + "</p><h6 class='text-sm mb-0'>صالح</h6></div></td>";
                        var td3 = "<td><div class='d-flex px-2 py-1 align-items-center'><div><i class='fa fa-bus text - secondary'></i></div><div class='ms-4'><small class='text-seconda'>Delivery</small><p class='text-xs font-weight-bold mb-0'>" + (this).DeliveryPerson + "</p></div></div></td>";
                        var td4 = "<td class='align-middle text-sm'><div class='d-flex px-2 py-1 align-items-center'><div><i class='fa fa-money text-secondary'></i></div><div class='ms-4'><small class='text-seconda'>" + (this).PaymentType + "</small><p class='text-xs font-weight-bold mb-0'>" + (this).TPrice + "  KWD</p></div></div></td>";
                        var td5 = "<td class='w-30'><div class='text-center1'><p class='text-xs font-weight-bold mb-0 text-secondary'>Scheduled</p><h6 class='text-sm mb-0'>" + (this).ScheduleTime + " </h6></div></td>";
                        var td6 = "<td><div class='text-center text-success'><span><i class='fa fa-circle fs-6'></i><small>" + (this).Status + " </small></span></div></td></tr>";

                        var rowData = (tr + td1 + td2 + td3 + td4 + td5 + td6);
                        $(tbody).append(rowData);

                    });

                    var modCount = 0;
                    if ((totalRows % rowsOfPage) > 0) {
                        modCount = 1;
                    }

                    var totalPageBtn = parseInt(totalRows / rowsOfPage) + modCount;



                    if (totalPageBtn > 1) {
                        for (var i = 0; i < totalPageBtn; i++) {

                            if (pgNm == (i + 1)) {
                                var li = "<li class='page-item pgli active' pageNumber='" + (i + 1) + "'><a class='page-link'>" + (i + 1) + "</a></li>";
                                $(pagingli).append(li);
                            }
                            else {
                                var li = "<li class='page-item pgli' pageNumber='" + (i + 1) + "'><a class='page-link'>" + (i + 1) + "</a></li>";
                                $(pagingli).append(li);
                            }
                        }
                    }

                }
                else {

                    $(tbody).append(`<h3> No Orders Found </h3>`);
                }

            },

            error: function (jqXHR, status) {
                // error handler
                console.log(jqXHR);
                alert('fail' + status.code);
            }
        });
    }







});