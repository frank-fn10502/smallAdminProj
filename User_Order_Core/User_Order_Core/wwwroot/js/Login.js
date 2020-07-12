function binding()
{
    let vm = new Vue({
        el: "#accountArea",
        data:{
            account: '',
            password:''
        },
        methods:{
            signIn: function(){
                let accountData = {
                    account: this.account,
                    password: this.password
                }
                console.log(`account: ${accountData.account} password: ${accountData.password}`);
                console.log(JSON.stringify(accountData));
                $.ajax({
                    type: "post",
                    url: "/Home/TryLogin",
                    data: JSON.stringify(accountData),
                    dataType: "Json",
                    contentType: 'application/json',
                    success: function (response) {
                        console.log(response);
                        if(response.isSuccess)
                        {
                            window.location.href = IndexPage;
                        }
                    }
                });
            }
        }
    });
}
$(function(){
    binding();
});