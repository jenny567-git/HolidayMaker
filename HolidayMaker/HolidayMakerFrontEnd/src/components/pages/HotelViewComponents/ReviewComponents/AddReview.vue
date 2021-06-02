<template>
  <div id="test2">
    <form @submit="onSubmit">
      <div class="row pt-5 pb-3">
        <h4 class="text text-start pb-5"></h4>
        <div class="col-md-6 text-end">Rating</div>
        <div class="col-md-6 text-start">
          <Rating v-model="rating" :cancel="false" />
        </div>
      </div>
      <div class="form-group">
        <label for="exampleFormControlInput1">Your name</label>
        <input v-model="name" type="text" name="name" class="form-control" />
      </div>
      <div class="form-group">
        <label for="exampleFormControlInput1">Your email</label>
        <input v-model="email" type="email" name="email" class="form-control" />
      </div>
      <div class="form-group">
        <label for="exampleFormControlTextarea1">Your message</label>
        <textarea
          v-model="message"
          name="message"
          class="form-control"
          rows="3"
        ></textarea>
      </div>
      <button type="submit" class="btn btn-primary">Submit</button>
    </form>
  </div>
</template>

<script>
import Rating from "primevue/rating";

export default {
  components: {
    Rating,
  },
  data() {
    return {
      //bind to model
      name: "",
      email: "",
      message: "",
      rating: null,
    };
  },
  methods: {
    onSubmit(e) {
      e.preventDefault();

      if (!this.message || !this.name || !this.email || !this.rating) {
        alert("Please fill in all fields");
        return;
      }

      let newReview = {
        rating: this.rating,
        message: this.message,
        hotelID: this.$route.params.id,
        //connect to real guest
        guestID: 1,
        // name: this.name,
        // email: this.email,
      };

      console.log(newReview);
      this.$store.dispatch("addReview", newReview);

      this.message = "";
      this.name = "";
      this.email = "";
      this.rating = null;

      document.querySelector(".text").innerHTML = "Thank you for your feedback!";
    },
  },
};
</script>


<style scoped>
#test2 {
  border-radius: 30px;
  background-color: rgba(107, 146, 83, 0.5);
  padding-left: 25px;
  padding-right: 25px;
  padding-bottom: 40px;
  margin-top: 20px;
  color: white;
  /* text-shadow: 2px 2px black; */
}
</style>