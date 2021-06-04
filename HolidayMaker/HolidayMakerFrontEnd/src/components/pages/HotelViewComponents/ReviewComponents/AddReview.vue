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
        <label for="exampleFormControlTextarea1">Your message</label>
        <textarea
          v-model="message"
          name="message"
          class="form-control"
          rows="3"
        ></textarea>
      </div>
      <button type="submit" id="btnSubmit" class="btn btn-primary">Submit</button>
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
      message: "",
      rating: null,
    };
  },
  mounted(){
    if(this.$store.state.guestId == null || this.$store.state.guestId == undefined){
      document.querySelector(".text").innerHTML = "Log in to submit a review";
      document.querySelector("#btnSubmit").disabled = true;
    }else{
      document.querySelector("#btnSubmit").disabled = false;
    }
  },
  methods: {
    onSubmit(e) {
      e.preventDefault();

      if (!this.message || !this.rating) {
        alert("Please fill in all fields");
        return;
      }

      let newReview = {
        rating: this.rating,
        message: this.message,
        hotelID: this.$route.params.id,
        //connected to guest in state
        guestID: this.$store.state.guestId,
      };

      console.log(newReview);

      this.addReview(newReview);


      this.message = "";
      this.rating = null;

      document.querySelector(".text").innerHTML =
        "Thank you for your feedback!";
    },
    addReview(payload){
      fetch("https://localhost:44356/api/Guest/AddReview", {
        method: "POST",
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify({
          rating: payload.rating,
          description: payload.message,
          hotelID: payload.hotelID,
          guestID: payload.guestID,
        }),
      })
        .then((response) => response.json())
        .then((data) => {
          console.log("Success:", data);
        })
        .catch((error) => {
          console.error("Error:", error);
        });
    }
  },
};
</script>


<style scoped>
#test2 {
  border-radius: 30px;
  background-color: white;
  padding-left: 25px;
  padding-right: 25px;
  padding-bottom: 40px;
  margin-top: 20px;
  color: black;
  /* text-shadow: 2px 2px black; */
}
</style>