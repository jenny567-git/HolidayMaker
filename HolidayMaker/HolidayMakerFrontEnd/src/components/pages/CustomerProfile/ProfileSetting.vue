<template>
        <div class="card-body">
            <div class="row gutters">
                <div class="col-xl-12 col-lg-12 col-md-12 col-sm-12 col-12">
                    <h6 class="mb-2 text-primary">Personal Details</h6>
                </div>
                <div class="col-xl-6 col-lg-6 col-md-6 col-sm-6 col-12">
                    <div class="form-group">
                        <label for="fullName">Full Name</label>
                        <input type="text" class="form-control" id="fullName" placeholder="Enter first name" v-model="guest.fullName">
                    </div>
                </div>
                <div class="col-xl-6 col-lg-6 col-md-6 col-sm-6 col-12">
                    <div class="form-group">
                        <label for="eMail">Email</label>
                        <input type="text" class="form-control" id="eMail" placeholder=" Enter last Name">
                    </div>
                </div>
                <div class="col-xl-6 col-lg-6 col-md-6 col-sm-6 col-12">
                    <div class="form-group">
                        <label for="phone">Phone</label>
                        <input type="text" class="form-control" id="phone" placeholder="Enter phone number">
                    </div>
                </div>
                <div class="col-xl-6 col-lg-6 col-md-6 col-sm-6 col-12">
                    <div class="form-group">
                        <label for="website">Email</label>
                        <input type="email" class="form-control" id="website" placeholder=" Enter email ID">
                    </div>
                </div>
            </div>
            <div class="row gutters">
                <div class="col-xl-12 col-lg-12 col-md-12 col-sm-12 col-12">
                    <h6 class="mt-3 mb-2 text-primary">Address</h6>
                </div>
                <div class="col-xl-6 col-lg-6 col-md-6 col-sm-6 col-12">
                    <div class="form-group">
                        <label for="Street">Street</label>
                        <input type="text" class="form-control" id="Street" placeholder="Enter Street">
                    </div>
                </div>
                <div class="col-xl-6 col-lg-6 col-md-6 col-sm-6 col-12">
                    <div class="form-group">
                        <label for="ciTy">City</label>
                        <input type="text" class="form-control" id="ciTy" placeholder="Enter City">
                    </div>
                </div>
                <div class="col-xl-6 col-lg-6 col-md-6 col-sm-6 col-12">
                    <div class="form-group">
                        <label for="zIp">Zip Code</label>
                        <input type="text" class="form-control" id="zIp" placeholder="Zip Code">
                    </div>
                </div>
                <div class="col-xl-12 col-lg-12 col-md-12 col-sm-12 col-12">
                    <h6 class="mt-3 mb-2 text-primary">Password</h6>
                </div>
                <div class="col-xl-6 col-lg-6 col-md-6 col-sm-6 col-12">
                    <div class="form-group">
                        <label for="sTate"> New Password</label>
                        <input type="text" class="form-control" id="paSsword" placeholder="Enter New Password">
                    </div>
                </div>
                <div class="col-xl-6 col-lg-6 col-md-6 col-sm-6 col-12">
                    <div class="form-group">
                        <label for="zIp">Verify Password</label>
                        <input type="text" class="form-control" id="RePassword" placeholder="Re-enter Password">
                    </div>
                </div>
            </div>
            <div class="row gutters">
                <div class="col-xl-12 col-lg-12 col-md-12 col-sm-12 col-12">
                    <div class="text-right">
                        <button type="button" id="submit" name="submit" class="btn btn-secondary">Cancel</button>
                        <button type="button" id="submit" name="submit" class="btn btn-primary">Update</button>
                    </div>
                </div>
            </div>
        </div>
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
        console.log("hej")
        document.querySelector('.form1').reset()
      }
  }
}
</script>

<style scoped>

    label{
        color: black;
    }
    
</style>
