<template>
        <div class="row profile">
            <div class="col-md-3">
                <div class="profile-sidebar">
                    <!-- SIDEBAR USERPIC -->
                    <div class="profile-userpic">
                        <div class="text-center">
                            <img src="http://ssl.gstatic.com/accounts/ui/avatar_2x.png" class="avatar img-circle img-thumbnail" alt="avatar">
                          </div>
                          <br>
                          <div class="container">
                                <h6>Upload a different photo</h6>
                            <div class="input-group mb-3">
                            
                            <div class="custom-file">
                                <input type="file" class="custom-file-input" id="inputGroupFile01">
                                <label class="custom-file-label" for="inputGroupFile01"></label>
                            </div>
                            </div>
                          </div>
                    </div>
                    <!-- END SIDEBAR USERPIC -->
                    <!-- SIDEBAR USER TITLE -->
                    <div class="profile-usertitle">
                        <div class="profile-usertitle-name">
                            <p>{{user.fullName}}</p>
                            <p>{{user.email}}</p>
                        </div>
                    </div>
                    <!-- END SIDEBAR USER TITLE -->
                    <!-- SIDEBAR BUTTONS -->
                    <ul class="profile-userbuttons">
                        <a class="btn btn-primary" style="background-color: #3b5998;" href="#!" role="button"
                        ><i class="fab fa-facebook-f"></i></a>
                        <a class="btn btn-primary" style="background-color: #55acee;" href="#!" role="button"
                        ><i class="fab fa-twitter"></i></a>
                        <a class="btn btn-primary" style="background-color: #dd4b39;" href="#!" role="button"
                        ><i class="fab fa-google"></i></a>
                        <a class="btn btn-primary" style="background-color: #ac2bac;" href="#!" role="button"
                        ><i class="fab fa-instagram"></i></a>
                    </ul>
                    <!-- END SIDEBAR BUTTONS -->
                    <!-- SIDEBAR MENU -->
                    <div class="profile-usermenu">
                        <ul class="nav"> 
                            <li > <!-- class="active" -->
                                <i class="fas fa-user"></i>
                                <router-link :to="'/profile/'"> Home </router-link>
                                
                            </li>
                            <li>
                                <i class="fas fa-concierge-bell"></i>
                                <router-link :to="'/profile/bookings'"> Bookings </router-link>
                                
                            </li>
                            <li>
                                <i class="fas fa-hotel"></i>
                                <router-link :to="'/profile/favorite'"> Saved Hotels </router-link>
                            </li>
                            <li>
                                <i class="fas fa-users-cog"></i>
                                <router-link :to="'/profile/profileSetting'"> Settings </router-link>
                            </li>
                        </ul>
                    </div>
                    <!-- END MENU -->
                </div>
            </div>
            <div class="col-md-9">
                <div class="profile-content">
                    <router-view></router-view>
                </div>
            </div> 
        </div>
</template>

<script>
export default {
    data() {
        return {
            fullName: "",
            eMail: "",
        };
    },
    computed: {
    loggedIn(){
            return this.$store.state.user.loggedIn
    },
    user() {
      return this.$store.state.user;
    },
    
  },
}

</script>

<style scoped>

    .nav {
        display: block;
    }
    /* Profile container */
    .profile {
        margin: 20px 0;
    }

    /* Profile sidebar */
    .profile-sidebar {
        padding: 20px 0 20px 0;
        background: #fff;
        border-radius: 30px;
        position:relative;
        right: 15px;
    }
    
    .profile-userpic img {
        float: none;
        margin: 0 auto;
        width: 70%;
        height: 70%;
        -webkit-border-radius: 50% !important;
        -moz-border-radius: 50% !important;
        border-radius: 50% !important;
    }
    
    .profile input{
        /* padding-left:30px; */
    }
    
    .profile-usertitle {
        text-align: center;
        margin-top: 20px;
    }
    
    .profile-usertitle-name {
        color: #5a7391;
        font-size: 16px;
        font-weight: 600;
        margin-bottom: 7px;
    }
    
    .profile-usertitle-job {
        text-transform: uppercase;
        color: #5b9bd1;
        font-size: 12px;
        font-weight: 600;
        margin-bottom: 15px;
    }
    
    .profile-userbuttons {
        position: relative;
        right: 15px;
        margin-top: 10px;
    }
    
    .profile-userbuttons .btn {
        font-size: 14px;
        padding: 6px 12px;
        margin-right: 5px;
    }
    
    .profile-userbuttons .btn:last-child {
        margin-right: 0px;
    }
        
    .profile-usermenu {
        margin-top: 30px;
    }
    
    .profile-userbuttons ul{
        display:block;
    }
    
    .profile-usermenu ul li {
        border:  1px solid #f0f4f7;
        /* border-top: 2px solid #f0f4f7;
        border-bottom: 2px solid #f0f4f7; */
    }
    
    /* .profile-usermenu ul li:last-child {
        border-bottom: none;
    } */
    
    .profile-usermenu ul li a {
        color: #93a3b5;
        font-size: 14px;
        font-weight: 400;
        /* display: block; */
    }
    
    .profile-usermenu ul li a i {
        margin-right: 8px;
        font-size: 14px;
        /* display: block; */
    }
    
    .profile-usermenu ul li a:hover {
        background-color: #fafcfd;
        color: #5b9bd1;
    }
    
    .profile-usermenu ul li.active {
        border-bottom: none;
    }
    
    .profile-usermenu ul li.active a {
        color: #5b9bd1;
        background-color: #f6f9fb;
        border-left: 2px solid #5b9bd1;
        margin-left: -2px;
    }
    
    /* Profile Content */
    .profile-content {
        padding: 20px;
        background: #fff;
        min-height: 800px;
        min-width: 217mm;
        border-radius: 30px;
    }
</style>

