<template>
    <html lang="en">
        <head>
            <meta charset="UTF-8">
            <title>Simple Navbar with flexbox</title>
        </head>
            <header>
                <img class="" src="/src/assets/hotel_logo4_tempfix.png" alt="" height="120">
                <nav>
                    <ul class="nav-area">
                        <li><a href="#"><router-link to="/hotels/1">Hotel 1 | </router-link></a></li>
                        <li><a href="#"><router-link to="/hotels/2">Hotel 2 | </router-link></a></li>
                        <li><a href="#"><router-link to="/result">Search result view | </router-link></a></li>
                        <li><a href="#"><router-link to="/addReview">Add review </router-link></a></li>
                        <li><a href="#">Temp5</a></li>
                    </ul>
                </nav>
                 <li class="nav-item dropdown">
                <a class="nav-link dropdown-toggle pi pi-user" id="navbarDropdownMenuLink" role="button" data-bs-toggle="dropdown" aria-expanded="false" style="fontSize: 2rem">
                </a>
                <ul class="dropdown-menu" aria-labelledby="navbarDropdownMenuLink">
                    <li><a class="dropdown-item" href="#">Log in</a></li>
                    <li><a class="dropdown-item" href="#">Log out</a></li>
                    <li><a class="dropdown-item" href="#">Register</a></li>
                </ul>
                </li>
            </header>
    </html>
</template>

<script>
import { defineProps, reactive } from 'vue'
import Button from 'primevue/Button';

defineProps({
  msg: String,
  component:{
    Button
  }

})
</script>

<style scoped>


* {
    margin: 0;
    padding: 0;
    box-sizing: border-box
}

a {
    text-decoration: none;
}

header {
    margin-top: -60px;
    margin-bottom: 30px;
    display: -webkit-flex;
    display: -moz-flex;
    display: -ms-flex;
    display: -o-flex;
    display: flex;
    justify-content: space-between;
    align-items: center;
    padding: 30px 70px;
    background:#202a38;
    border-style: solid;
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

.nav-area li a:hover {
    color: #ffffff;
}

.nav-item {
 list-style-type: none;
}

.pi {
    color: rgb(224, 224, 224);
    list-style-type: none;
}

.btn-area {
    cursor: pointer;
    color: #fff;
    font-size: 16px;
    letter-spacing: 2px;
    text-transform: uppercase;
    padding: 10px 30px;
    border-radius: 5px;
    background: #c7b09e;
}

/* nav {
    justify-content: space-around;
    align-items: center;
    min-height: 10vh;
    background-color: #2f2f2f;
    margin-bottom: 30px;
    box-shadow: 0 6.8px 2.7px rgba(0, 0, 0, 0.072), 0 12.9px 6.9px rgba(0, 0, 0, 0.106), 0 19.2px 14.2px rgba(0, 0, 0, 0.123), 0 28.3px 29.2px rgba(0, 0, 0, 0.133), 0 61px 80px rgba(0, 0, 0, 0.15);
    position: relative;
}
.nav .nav-item {
    align-items:center;
    display: flex;
    list-style: none;
}
.nav-item .dropdown {

} */

</style>