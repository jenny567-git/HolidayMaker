<template>
<header id="header">
				<div class="header-top">
					<div class="container">
			  		<div class="row align-items-center">
			  			<div class="col-lg-6 col-sm-6 col-6 header-top-left">
			  							
			  			</div>
			  			<div class="col-lg-6 col-sm-6 col- header-top-right">
							<div class="nav-menu">
                        <div v-if="!loggedIn">
                            <a href=""><router-link to="/login">Log in</router-link></a>
                            <a href="#"><router-link to="/registration">Register</router-link></a>
                        </div>
                        <div v-if="loggedIn">
                          <a  href="" @click="logout()">Log out</a>
                          <a  href=""><router-link to="/Profile">Profile</router-link></a>
                        </div>
							</div>
                        <div id="user" v-if="loggedIn">
                          <ul>
                              <li ><a>{{user.email}}</a></li>
                         </ul>
                        </div>
			  			</div>
			  		</div>			  					
					</div>
				</div>
				<div class=" main-menu">
					<div class="row align-items-center justify-content-between d-flex">
				      <div id="logo">
                <router-link to="/"><img src="/src/assets/Logo5_cropped.png" alt="" title="" height="80"></router-link>
				      </div>
					</div>
				      <nav id="nav-menu-container">
				        <ul class="nav-menu">
				          <li><a href="">Work With us</a></li>
				          <li><a href="">Tourist Attraction</a></li>
                  <li><a href="">Contacts Us</a></li>
				        </ul>
				      </nav><!-- #nav-menu-container -->					      		  
				</div>
			</header><!-- #header -->
</template>



<script>
export default {
  components: {},
  data() {
    return {
      userInfo: {},
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
  created() {
  },
  methods:{
      logout(){
            this.$store.dispatch('logout')
            
        }
  },
  
};
</script>


<style scoped>

#user{
  color:rgb(131, 255, 93);
  padding-right:25px;
}

nav#nav-menu-container{
  display:inline-block;
  padding-top:10px;
}

ol, ul {
  margin: 0;
  padding: 0;
  list-style: none;
}

select {
  display: block;
}

figure {
  margin: 0;
}

a {
  -webkit-transition: all 0.3s ease 0s;
  -moz-transition: all 0.3s ease 0s;
  -o-transition: all 0.3s ease 0s;
  transition: all 0.3s ease 0s;
}

/*Header*/

.header-top {
  font-size: 12px;
  padding: 6px 0px;
  background-color:rgb(83 193 110);
}

.header-top a {
  color: rgb(255, 255, 255);
  -webkit-transition: all 0.3s ease 0s;
  -moz-transition: all 0.3s ease 0s;
  -o-transition: all 0.3s ease 0s;
  transition: all 0.3s ease 0s;
}

.header-top a:hover {
  color: #22cf3f;
}

.header-top ul li {
  display: inline-block;
  margin-right: 15px;
}

@media (max-width: 414px) {
  .header-top ul li {
    margin-right: 0px;
  }
}

.header-top .header-top-left a {
  margin-right: 8px;
}

.header-top .header-top-right {
  text-align: right;
}

.header-top .header-top-right .header-social a {
  color: #fff;
  margin-left: 15px;
  -webkit-transition: all 0.3s ease 0s;
  -moz-transition: all 0.3s ease 0s;
  -o-transition: all 0.3s ease 0s;
  transition: all 0.3s ease 0s;
}

.header-top .header-top-right .header-social a:hover {
  color: #11b82d;
}

.main-menu {
  padding-top: 10px;
  background: #33393a;
  padding-left: 15px;
  padding-right: 15px;
  border-bottom:solid 2px;
  border-color:black;
}

#header {
  position:absolute;
  left: 0;
  top: 0;
  right: 0;
  transition: all 0.5s;
  z-index: 997;
} 

/* #header.header-scrolled {
  transition: all 0.5s;
  background-color: rgba(34, 34, 34, 0.9);
}

#header.header-scrolled .header-top {
  display: none;
}

 #header.header-scrolled .main-menu {
  background: transparent;
} */

/*--------------------------------------------------------------
# Navigation Menu
--------------------------------------------------------------*/
/* Nav Menu Essentials */
.nav-menu, .nav-menu * {
  margin: 0;
  padding: 0;
  list-style: none;
}

.nav-menu ul {
  position: absolute;
  display: none;
  top: 100%;
  right: 0;
  z-index: 99;
}

.nav-menu li {
  position: relative;
  white-space: nowrap;
}

.nav-menu > li {
  float: left;
}

.nav-menu li:hover > ul,
.nav-menu li.sfHover > ul {
  display: block;
}

.nav-menu ul ul {
  top: 0;
  right: 100%;
}

.nav-menu ul li {
  min-width: 180px;
}

/* Nav Menu Arrows */
/* .sf-arrows .sf-with-ul {
  padding-right: 30px;
}

.sf-arrows .sf-with-ul:after {
  content: "\f107";
  position: absolute;
  right: 15px;
  font-family: FontAwesome;
  font-style: normal;
  font-weight: normal;
} */

/* .sf-arrows ul .sf-with-ul:after {
  content: "\f105";
} */

/* Nav Meu Container */
@media (max-width: 768px) {
  #nav-menu-container {
    display: none;
  }
  
}

/* Nav Meu Styling */
.nav-menu a {
  padding: 0 8px 0px 8px;
  text-decoration: none;
  display: inline-block;
  color: #fff;
  font-weight: 500;
  font-size: 12px;
  text-transform: uppercase;
  outline: none;
}


.nav-menu li:hover > a {
  color: #309c4b;
}

.nav-menu > li {
  margin-left: 4px;
}

.nav-menu ul {
  margin: 22px 0 0 0;
  padding: 10px;
  box-shadow: 0px 0px 30px rgba(127, 137, 161, 0.25);
  background: #fff;
}

.nav-menu ul li {
  transition: 0.3s;
}

.nav-menu ul li a {
  padding: 5px 10px;
  color: #333;
  transition: 0.3s;
  display: block;
  font-size: 12px;
  text-transform: none;
}

.nav-menu ul li:hover > a {
  color: #19df23;
}

.nav-menu ul ul {
  margin-right: 10px;
  margin-top: 0;
}

</style>

