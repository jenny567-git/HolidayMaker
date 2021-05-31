<template>
  <div>
    <form @submit.prevent="addGuest">
  <h1>testa</h1>
  <div>
    <label for="">Fullname</label>
    <input type="text" v-model="guest.FullName">
  </div>

  <div>
    <label for="">Street</label>
    <input type="text" v-model="guest.Street">
  </div>

  <div>
    <label for="">Zipcode</label>
    <input type="text" v-model="guest.ZipCode">
  </div>
  <div>
    <label for="">City</label>
    <input type="text" v-model="guest.City">
  </div>

  <div>
    <label for="">Country</label>
    <input type="text" v-model="guest.Country">
  </div>

  <div>
    <label for="">Phone</label>
    <input type="text" v-model="guest.Phone">
  </div>
  <div>
    <label for="">Email</label>
    <input type="email" v-model="guest.Email">
  </div>
  <button>Submit</button>
  </form>
</div>
</template>


<script>
export default {
  data(){
    return{
      guest:{
        FullName: "",
        Street: "",
        ZipCode: "",
        City: "",
        Country: "",
        Phone:"",
        
        Email: ""
      }
    }
  },
  async mounted(){

  },
  methods:{
    async addGuest(){
      await fetch('https://localhost:44356/api/Guest/addGuest', {
        method:'Post',
        headers:{
          'Accept': 'application/json',
          'Content-type': 'application/json'
        },
        body: JSON.stringify({FullName: this.guest.FullName, Street:this.guest.Street, ZipCode:this.guest.ZipCode, City:this.guest.City, Country:this.guest.Country, Phone:this.guest.Phone, Email:this.guest.Email})
      
      })
    }
  }
}
</script>