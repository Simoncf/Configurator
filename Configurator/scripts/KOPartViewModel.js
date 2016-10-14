var KOPartViewModel = function (data) {

    var self = this;
    if (data != null) {
        ko.mapping.fromJS(data, { Parts: partModelMapping }, self);
    } else {
        self.Parts = ko.observableArray();
        self.ProductId = ko.observable();
        self.ProductName = ko.observable();
        
    }
    self.ShowProduct = function () {
        location.href = urlBefore;

    }
};
var partModelMapping = {
    create: function (options) {
        return new PartModel(options.data);
    }
};
var PartModel = function (data) {

    var self = this;
    if (data != null) {
        ko.mapping.fromJS(data, { }, self);
    } else {
        self.Id = ko.observable();
        self.Name = ko.observable();
        self.ProductId = ko.observable();
    }
    self.ShowItemTypes = function () {
        //alert('Lalal');

        location.href = url + '/' + self.Id();
    }
};

var NewPartModel = function () {
    var self = this;
    self.Id = ko.observable();
    self.Name = ko.observable();
    self.ProductId = ko.observable();
    var newPart;
    self.Save = function (newPart) {
        newPart = new PartModel();
        newPart.Id(0);
        newPart.Name(self.Name());
        newPart.ProductId($('#productId').text());
        var obj = ko.mapping.toJSON(newPart);
        $.ajax({
            url: "/Administration/SavePart",
            type: "Post",
            data: obj,
            contentType: "application/json",
            success: function () {
                $('#newPart').val("");
                koPartViewModel.Parts.push(newPart);
            }
        })
    }
}