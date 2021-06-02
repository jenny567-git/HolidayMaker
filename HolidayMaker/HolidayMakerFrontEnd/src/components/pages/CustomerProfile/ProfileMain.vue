<template>
    <div class="container">
        <div class="row profile">
            <div class="col-md-3">
                <div class="profile-sidebar">
                    <!-- SIDEBAR USERPIC -->
                    <div class="profile-userpic">
                        <div class="text-center">
                            <img src="http://ssl.gstatic.com/accounts/ui/avatar_2x.png" class="avatar img-circle img-thumbnail" alt="avatar">
                          </div>
                            <br>
                            <h6>Upload a different photo...</h6>
                            <div class="input-group input-group-sm mb-3">
                                <input type="file" class="form-control" aria-label="Sizing example input" aria-describedby="inputGroup-sizing-sm">
                            </div>
                    </div>
                    <!-- END SIDEBAR USERPIC -->
                    <!-- SIDEBAR USER TITLE -->
                    <div class="profile-usertitle">
                        <div class="profile-usertitle-name">
                            <p>Fullname</p>
                            <p>Email</p>
                        </div>
                    </div>
                    <!-- END SIDEBAR USER TITLE -->
                    <!-- SIDEBAR BUTTONS -->
                    <!-- <div class="profile-userbuttons">
                        <button type="button" class="btn btn-success btn-sm">Follow</button>
                        <button type="button" class="btn btn-danger btn-sm">Message</button>
                    </div> -->
                    <!-- END SIDEBAR BUTTONS -->
                    <!-- SIDEBAR MENU -->
                    <div class="profile-usermenu">
                        <ul class="nav"> 
                            <li > <!-- class="active" -->
                                <a href="#">
                                <i class="fas fa-user"></i>
                                Profile </a>
                            </li>
                            <li>
                                <a href="#">
                                <i class="fas fa-concierge-bell"></i>
                                Bookings </a>
                            </li>
                            <li>
                                <a href="#"> <!--target="_blank" -->
                                <i class="fas fa-hotel"></i>
                                Saved Hotels </a>
                            </li>
                            <li>
                                <a href="#">
                                <i class="fas fa-users-cog"></i>
                               Settings</a>
                            </li>
                        </ul>
                    </div>
                    <!-- END MENU -->
                </div>
            </div>
            <div class="col-md-9">
                <div class="profile-content">
          
                </div>
            </div>
        </div>
    </div>
</template>

<script>

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
        padding: 20px 0 10px 0;
        background: #fff;
    }
    
    .profile-userpic img {
        float: none;
        margin: 0 auto;
        /* width: 50%;
        height: 50%; */
        -webkit-border-radius: 50% !important;
        -moz-border-radius: 50% !important;
        border-radius: 50% !important;
    }
    
    .profile input{
        padding-left:30px;
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
        text-align: center;
        margin-top: 10px;
    }
    
    .profile-userbuttons .btn {
        text-transform: uppercase;
        font-size: 11px;
        font-weight: 600;
        padding: 6px 15px;
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
        border-bottom: 1px solid #f0f4f7;
    }
    
    .profile-usermenu ul li:last-child {
        border-bottom: none;
    }
    
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
    }
</style>

