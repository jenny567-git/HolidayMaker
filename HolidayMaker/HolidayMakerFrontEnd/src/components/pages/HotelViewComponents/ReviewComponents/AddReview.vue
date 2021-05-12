<template>
    <div>
    <form>
        <div class="form-group">
        <label for="exampleFormControlInput1">Your name</label>
        <input v-model="name" type="text" class="form-control" />
      </div>
      <div class="form-group">
        <label for="exampleFormControlInput1">Your email</label>
        <input v-model="email" type="email" class="form-control" />
      </div>
      <div class="form-group">
        <label for="exampleFormControlTextarea1">Your message</label>
        <textarea v-model="message" class="form-control" rows="3"></textarea>
      </div>
      <button type="submit" class="btn btn-primary">Submit</button>
    </form>
  </div>
</template>

<script>
  export default{
    computed:{
        // addreview(){
            
        //     name(value) {
        //     this.$store.commit('updateName', value)
        // },
        // email(value) {
        //     this.$store.commit('updateEmail', value)
        // },
        // message(value) {
        //     this.$store.commit('updateMessage', value)
        // }
        // }
        
    }
  }
</script>