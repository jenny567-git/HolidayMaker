<template>
    <html>
        <head>
        <link href="https://fonts.googleapis.com/css?family=Ubuntu" rel="stylesheet">
        <meta name="viewport" content="width=device-width, initial-scale=1" />
        <link rel="stylesheet" href="path/to/font-awesome/css/font-awesome.min.css">
        <title>Log in</title>
        </head>
        
        
            <div class="main">
                    <p class="sign" align="center">Registration</p>
                   
                        <form class="form1" @submit.prevent="checkPasswords">
                        <input class="un" type="text" align="center" placeholder="Fullname" required v-model="guest.Fullname">
                        <input class="un" type="text" align="center" placeholder="Street" required v-model="guest.Street">
                        <input class="un" type="text" align="center" placeholder="Zipcode" required v-model="guest.Zipcode">
                        <input class="un" type="text" align="center" placeholder="City" required v-model="guest.City">
                        <input class="un" type="text" align="center" placeholder="Country" required v-model="guest.Country">
                        <input class="un" type="text" align="center" placeholder="Phone" required v-model="guest.Phone">
                        <input class="un" type="email" align="center" placeholder="Email" required v-model="guest.Email">


                        <input  class="password"  type="password"  align="center" placeholder="Password" required v-model="guest.Password">
                        <input class="confirmPassword" type="password" align="center" placeholder="Repeat-Password" required v-model="guest.confirmPassword">
                        <p class="text"></p>

                        <ul class="ul">
                            <li>
                            <button class="submit" align="center">Confirm</button>
                            </li>
                            <br>
                            <li>
                            <button class="submit" align="center">Cancel</button>
                            </li>
                        </ul>
                </form>
              
            </div>
     
    </html>
</template>





<script>

export default {

  components:{
  },
  data(){
    return{
      guest:{
        Fullname: "",
        Street: "",
        Zipcode: "",
        City:"",
        Country:"",
        Phone:"",
        Email: "",
        Password: "",
        confirmPassword:""
      }
    }
  },
  async mounted(){

  },
  methods:{
    checkPasswords(){
        var password = document.querySelector('.password').value;
        var confirmPassword = document.querySelector('.confirmPassword').value;
        
        if(confirmPassword !=password){
          document.querySelector('.text').innerHTML = "Passwords dont match"
          
          
        }else if(password ===confirmPassword){
          document.querySelector('.text').innerHTML="";
          this.addGuest()
        }
    },
    
    async addGuest(){
      
      await fetch('https://localhost:44356/api/Guest/addGuest', {
        method:'Post',
        headers:{
          'Accept': 'application/json',
          'Content-type': 'application/json'
        },
        body: JSON.stringify({Fullname:this.guest.Fullname, Street:this.guest.Street, Zipcode:this.guest.Zipcode, City:this.guest.City, Country:this.guest.Country, Phone:this.guest.Phone, Email:this.guest.Email, Password:this.guest.Password}),
        
      })
       this.resetForm()
    },
      resetForm(){
        document.querySelector('.form1').reset()
      }
  }
}
</script>


<style scoped>
    
        
        .main {
            background-color: #ffffff;
            width: 400px;
            height: 850px;
            margin: 7em auto;
            border-radius: 1.5em;
            box-shadow: 0px 11px 35px 2px rgba(0, 0, 0, 0.14);
        }
        
        .sign {
            padding-top: 40px;
            color: #548358;
            font-family: 'Ubuntu', sans-serif;
            font-weight: bold;
            font-size: 23px;
        }
        
        .un {
        width: 76%;
        color: rgb(38, 50, 56);
        font-weight: 700;
        font-size: 14px;
        letter-spacing: 1px;
        background: rgba(136, 126, 126, 0.04);
        padding: 10px 20px;
        border: none;
        border-radius: 20px;
        outline: none;
        box-sizing: border-box;
        border: 2px solid rgba(0, 0, 0, 0.02);
        margin-bottom: 50px;
        text-align: center;
        margin-bottom: 27px;
        font-family: 'Ubuntu', sans-serif;
        }

         .password {
        width: 76%;
        color: rgb(38, 50, 56);
        font-weight: 700;
        font-size: 14px;
        letter-spacing: 1px;
        background: rgba(136, 126, 126, 0.04);
        padding: 10px 20px;
        border: none;
        border-radius: 20px;
        outline: none;
        box-sizing: border-box;
        border: 2px solid rgba(0, 0, 0, 0.02);
        margin-bottom: 50px;
        text-align: center;
        margin-bottom: 27px;
        font-family: 'Ubuntu', sans-serif;
        }
         .confirmPassword {
        width: 76%;
        color: rgb(38, 50, 56);
        font-weight: 700;
        font-size: 14px;
        letter-spacing: 1px;
        background: rgba(136, 126, 126, 0.04);
        /* padding: 10px 20px; */
        border: none;
        border-radius: 20px;
        outline: none;
        box-sizing: border-box;
        border: 2px solid rgba(0, 0, 0, 0.02);
        margin-bottom: 50px;
        text-align: center;
        margin-bottom: 27px;
        font-family: 'Ubuntu', sans-serif;
        }
        
        form.form1 {
            padding-top: 40px;
        }
        
        .pass {
                width: 76%;
        color: rgb(38, 50, 56);
        font-weight: 700;
        font-size: 14px;
        letter-spacing: 1px;
        background: rgba(136, 126, 126, 0.04);
        padding: 10px 20px;
        border: none;
        border-radius: 20px;
        outline: none;
        box-sizing: border-box;
        border: 2px solid rgba(0, 0, 0, 0.02);
        margin-bottom: 50px;
        text-align: center;
        margin-bottom: 27px;
        font-family: 'Ubuntu', sans-serif;
        }
        .text{
          color:red;
          font-size: 12px;
                
          
        }
       
      
    
        .un:focus, .pass:focus {
            border: 2px solid rgba(0, 0, 0, 0.18) !important;
            
        }
        
        .submit {
        cursor: pointer;
            border-radius: 5em;
            color: #fff;
            background: linear-gradient(to right, #478151, #45705e);
            border: 0;
            padding-left: 40px;
            padding-right: 40px;
            padding-bottom: 10px;
            padding-top: 10px;
            font-family: 'Ubuntu', sans-serif;
            font-size: 13px;
            box-shadow: 0 0 20px 1px rgba(0, 0, 0, 0.04);
            
        }

        .ul {
            list-style: none;
            padding-right:40px;
        }

        .forgot {
            text-shadow: 0px 0px 3px rgba(117, 117, 117, 0.12);
            color: #E1BEE7;
            padding-top: 15px;
        }
        
        a {
            text-shadow: 0px 0px 3px rgba(117, 117, 117, 0.12);
            color: #507050;
            text-decoration: none
        }
        
        @media (max-width: 600px) {
            .main {
                border-radius: 0px;
            }
        }
</style>