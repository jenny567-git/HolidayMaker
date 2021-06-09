<template>
 <Card id="test3">
   <template #content>
    <div class="p-grid">
      <div class="p-col-12 p-md-6 p-lg-4">
        <label for="searchInput" id="searchField">Location/Hotel name </label>
        <Searchfield @input-changed="setSearchText"/>
      </div>
      <div class="p-col-12 p-md-6 p-lg-4">
        <label for="range" id="range">Dates</label>

        <div class="p-fluid" id="calendar">
          <Calendar />
        </div>
      </div>
      <div class="p-col-12 p-md-6 p-lg-2" id="guestsBtn">
        <label for="guest">Guests & rooms </label>
        <SearchDropdown />
      </div>
      <div class="p-col-12 p-md-6 p-lg-2" id="searchBtn">
          <Button  class="" label="Search" @click="Search" :loading="isLoading"/>
      </div>
    </div>
   </template>
 </Card>
</template>

<script>
import Button from "primevue/button";
import Calendar from "./Datepicker.vue";
import SearchDropdown from "./SearchDropdown.vue";
import Searchfield from "./Searchfield.vue";
import Card from 'primevue/card';

export default {
  data(){
    return{
      searchString: ''
    }
  },
  components: {
    Searchfield,
    Button,
    Calendar,
    SearchDropdown,
    Card,
  },
  methods: {
    onSubmit() {},
    Search(event){
        this.$store.state.searchButtonLoading = true;
        this.$store.dispatch('searchHotels', this.searchString);
      },
      setSearchText(value){
          this.searchString = value;
      }
  },
  computed:{
      isLoading(){
        return this.$store.state.searchButtonLoading;
      }
    }
};
</script>

<style scoped>

#test3{
  margin-top: 30px;
  border-radius: 20px;
  margin-top: 36mm;
}

#searchBtn{
  margin-top: 46px;
}

#range{
  display: block;
}

#guestsBtn{
  align-self: center;
}

#searchField {
  margin-top: 3px;
}

#calender {
 margin-top: 5px;
}


.container {
  background-color: #7e7e7e;
  color: #182436;
  border-radius: 25px;
  padding-left: 50px;
  padding-right: 50px;
  padding-top: 30px;
  padding-bottom: 30px;
}

button.p-button.p-component{
  background: #53c16e;
  border:#14a04d;
  text-decoration: none;
}

.p-button:enabled:hover{
  background:#348047 !important;
  border-color:#14a04d;
  text-decoration: none;
}

</style>