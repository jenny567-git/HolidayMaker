<template>
    <html lang="en">
        <head>
            <meta charset="UTF-8">
            <title>Simple Navbar with flexbox</title>
        </head>
            <header>
                <a href="">Hello</a>
                <!-- <img class="" src="/src/assets/Logo5_cropped.png" alt="" height="80"> -->
                <nav>
                    <ul class="nav-area">
                        <li><a href="#"><router-link to="/hotels/1">Hotel 1 | </router-link></a></li>
                        <li><a href="#"><router-link to="/hotels/2">Hotel 2 | </router-link></a></li>
                        <li><a href="#"><router-link to="/result">Search result view | </router-link></a></li>
                        <li><a href="#"><router-link to="/addReview">Add review </router-link></a></li>
                        <li><a href="#"><router-link to="/checkout">Checkout</router-link></a></li>
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