<template>
    <header>
    <nav class="navbar navbar-expand-lg navbar-light bg-light">
        <div class="container-fluid">
            <a class="navbar-brand" href="#">
                <img id="img_logo" alt="logo" src="/src/assets/logo.png">
            </a>
            <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarNavDropdown" aria-controls="navbarNavDropdown" aria-expanded="false" aria-label="Toggle navigation">
            <span class="navbar-toggler-icon"></span>
            </button>
            <div class="collapse navbar-collapse" id="navbarNavDropdown">
            <ul class="navbar-nav">
                <li class="nav-item">
                <router-link to="/home">test | </router-link>
                </li>
                <li class="nav-item">
                <router-link to="/hotels/1">Hotel 1 | </router-link>
                </li>
                <li class="nav-item">
                <router-link to="/hotels/2">Hotel 2 | </router-link>
                </li>
                <li class="nav-item">
                <router-link to="/result">Search result view | </router-link>
                </li>
                <li class="nav-item">
                <router-link to="/addReview">Add review </router-link>
                </li>
                <li class="nav-item dropdown">
                <a class="nav-link dropdown-toggle pi pi-user" id="navbarDropdownMenuLink" role="button" data-bs-toggle="dropdown" aria-expanded="false" style="fontSize: 2rem">
                </a>
                <ul class="dropdown-menu" aria-labelledby="navbarDropdownMenuLink">
                    <li><a class="dropdown-item" href="#">Log in</a></li>
                    <li><a class="dropdown-item" href="#">Log out</a></li>
                    <li><a class="dropdown-item" href="#">Register</a></li>
                </ul>
                </li>
            </ul>
            </div>
        </div>
        </nav>
    </header>
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

nav {
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

}

</style>