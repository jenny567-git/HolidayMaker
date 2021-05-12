<template>
    <div>
    <form>
      <div class="pt-5">
        <RatingSlider/>
        </div>
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
import RatingSlider from './RatingSlider.vue'

  export default{
      components: {
        RatingSlider
    }
  }
</script>