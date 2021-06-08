<template>
    <html lang="en">
        <head>
            <meta charset="UTF-8">
            <title>Simple Navbar with flexbox</title>
        </head>
            <header>
                <img class="" src="/src/assets/Logo5_cropped.png" alt="" height="80">
                <nav>
                    <ul class="nav-area">
                        <li><a href="#"><router-link to="/hotels/1">Hotel 1 | </router-link></a></li>
                        <li><a href="#"><router-link to="/hotels/2">Hotel 2 | </router-link></a></li>
                        <li><a href="#"><router-link to="/result">Search result view | </router-link></a></li>
                        <li><a href="#"><router-link to="/checkout">Checkout</router-link></a></li>
                    </ul>
                </nav>



                <!-- Detta ska flyttas till ovanför ikonen till höger -->
                <div v-if="loggedIn">
                    <ul class="nav-area">
                        <li ><p>{{user.email}}</p></li>
                    </ul>
                    
                    
                   
                   
                </div>
                 <li class="nav-item dropdown">
                <a class="nav-link dropdown-toggle pi pi-user" id="navbarDropdownMenuLink" role="button" data-bs-toggle="dropdown" aria-expanded="false" style="fontSize: 2rem">
                </a>
                <ul class="dropdown-menu" aria-labelledby="navbarDropdownMenuLink">
                   
                    <div v-if="!loggedIn">
                    <li ><a class="dropdown-item" href="#"><router-link to="/login">Log in</router-link></a></li>
                    </div>

                    <div v-if="loggedIn">
                   <li ><a class="dropdown-item" href="" @click="logout()">Log out</a></li>
                   <li><a class="dropdown-item" href="#"><router-link to="/test">Profile</router-link>  </a></li>
                    </div>
                    
                    <li><a class="dropdown-item" href="#"><router-link to="/registration">Register</router-link></a></li>
                </ul>
                </li>
            </header>
    </html>
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


* {
    margin: 0;
    padding: 0;
    box-sizing: border-box
}

header{
    color:white;
}

a{
}

header {
    margin-top: -60px;
    display: -webkit-flex;
    display: -moz-flex;
    display: -ms-flex;
    display: -o-flex;
    display: flex;
    justify-content: space-between;
    align-items: center;
    padding: 12px 70px;
    background:#202a38;
    background: rgb(51, 57, 58);
}

.nav-area {
    list-style: none;
}

.nav-area li {
    display: inline-block;
    padding: 0 15px;
}

.nav-area li a {
    color: rgb(224, 224, 224);
}
.nav-area li p {
    color: rgb(224, 224, 224);
}

.nav-area li a:hover {
    color: #ffffff;
}

.nav-item {
 list-style-type: none;
}

.pi {
    color: rgb(224, 224, 224) !important;
    list-style-type: none;
}

/* .btn-area {
    cursor: pointer;
    color: #fff;
    font-size: 16px;
    letter-spacing: 2px;
    text-transform: uppercase;
    padding: 10px 30px;
    border-radius: 5px;
    background: #c7b09e;
}  */


</style>

