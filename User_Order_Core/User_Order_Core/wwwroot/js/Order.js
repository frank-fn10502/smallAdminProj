var statusList = ["Payment completed", "To be shipped"];
var data = [];
var product = { id: '', name: '', price: '' };
let vmProduct = new Vue(
    {
        el: '#productModal',
        data: {
            item: product
        }
    });
let vm = new Vue(
    {
        el: "#main",
        data: {
            isWait: true,
            headerDatas: [],
            bodyDatas: [],
            queueData: []
        },
        computed: {
            dataNeedShow: function () {
                return this.products.find(product => product.status === 'processing') !== undefined
            }
        },
        computed: {

        },
        methods: {
            checkClick: function (e, index) {


                let input = e.target.querySelector('input') || e.target;
                if (e.target.checked === undefined) {
                    input.checked = !input.checked;
                }

                if (input.checked) {
                    this.queueData.push(data[index]);
                }
                else {
                    let targetIndex = this.queueData.indexOf(data[index]);
                    this.queueData.splice(targetIndex, 1);
                }
            },
            confirm: function () {
                let self = this;
                this.queueData.forEach(x => {
                    x.status = 1;
                });
                $.ajax({
                    type: "post",
                    url: "https://localhost:44364/api/Order",
                    data: JSON.stringify(self.queueData),
                    dataType: "Json",
                    contentType: 'application/json',
                    success: function (response) {
                        alert("新增成功");
                    },
                    complete() {
                        self.queueData = [];
                    }
                });
            },
            showProduct: function (pid) {
                $.ajax({
                    type: "get",
                    url: `https://localhost:44364/api/product/${pid}`,
                    data: "data",
                    dataType: "json",
                    success: function (response) {
                        if (response.isSuccess) {
                            product = response.data;
                            // bindProduct();
                            vmProduct.$data.item = product;
                            $('#productModal').modal();
                        }
                    }
                });
            },
            statusText: function (index) {
                return statusList[this.bodyDatas[index].status];
            },
        }
    }
);

$(function () {
    $.ajax({
        type: "Get",
        url: "https://localhost:44364/api/Order",
        dataType: "json",
        success: function (response) {
            if (response.isSuccess) {
                data = response.data;
                vm.$data.isWait = false;
                vm.$data.bodyDatas = data;
                vm.$data.headerDatas = Object.keys(response.data[0]);

            }
            console.log(response);
        }
    });
    // setTimeout(() => {
    //     vm.$data.isWait = false;
    // }, 2000);
    console.log("ready jquery");
});