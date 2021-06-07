<template>
  <main>
    <Navigator/>
    <div class="view intro-2">
        <div class="full-bg-img">
            <div class="mask rgba-black-light flex-center">
              <div class="container">
                <Searcher/>
                <router-view/>
              </div>
                <div>
                    <div>
                        <br>
                        <br>
                        <br>
                        <br>
                        <br>
                        <br>
                        <br>
                        <br>
                        <br>
                    </div>
                </div>
            </div>
        </div>
        <figure>
            <figcaption></figcaption>
                <audio
                    controls
                    src="/src/assets/Media/Toto.mp3">
                        Your browser does not support the
                        <code>audio</code> element.
                </audio>
            </figure> 
    </div>
      <!-- <div style="background: url(https://wallpaperaccess.com/full/1198002.jpg);" class="page-holder bg-cover">
        <div class="container">
          <Searcher/>
          <router-view/>
        </div>
    </div> -->
        <Body v-if="showBody"/>
    <Footer/>
  </main>
</template>

<script>
import ConfirmDate from './components/pages/Datepicker/ConfirmDate.vue'
import Dialog from 'primevue/dialog';
import InputText from 'primevue/InputText';
import Button from 'primevue/button';
import Menu from 'primevue/menu';
import ColorPicker from 'primevue/colorpicker';
import Navigator from '/src/components/Navigator.vue';
import Footer from '/src/components/Footer.vue';
import Body from "/src/components/pages/MainPage/Body.vue";
import Searcher from './components/pages/SearchComponent/Search.vue'

export default {
  name: "App",
  components: {
    ConfirmDate,
    Dialog,
    ColorPicker,
    InputText,
    Button,
    Menu,
    Navigator,
    Footer,
    Body,
    Searcher,
  },
  data() {
        return {
          searchString: '',
          showBody: true,
            color2: '1976D2',
            items: [
            {
              label: 'Update',
              icon: 'pi pi-refresh',
              command: () => {
                this.$toast.add({severity:'success', summary:'Updated', detail:'Data Updated', life: 3000});
              }
            },
            {
              label: 'Delete',
              icon: 'pi pi-times',
              command: () => {
                this.$toast.add({ severity: 'warn', summary: 'Delete', detail: 'Data Deleted', life: 3000});
              }
            },
            {
              label: 'Vue Website',
              icon: 'pi pi-external-link',
              url: 'https://vuejs.org/'
            },
            {
              label: 'Router',
              icon: 'pi pi-upload',
              to: '/fileupload'
            }
			    ]
        }
    },
    methods:{
      toggle(event) {
        this.$refs.menu.toggle(event);
      },
      Search(event){
        this.$store.state.searchButtonLoading = true;

        this.$store.dispatch('searchHotels', this.searchString);
      }
    },
    computed:{
      isLoading(){
        return this.$store.state.searchButtonLoading;
      },
      showBody(){
        return this.$route.path == '/' ? true : false;
      }
    }
}


</script>

<style>
#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
  margin-top: 60px;
}

.input-group {
  margin-left: auto;
  margin-right: auto;
  display: flex;
  width: fit-content;
  align-content: center;
}

.intro-2 {
    background: url("https://wallpaperaccess.com/full/1198002.jpg") center center;
    background-size: cover !important;
    background-position: top;
    background-repeat: no-repeat;
    background-attachment: fixed;
    border-color: black;
    border-style: solid;
    border-width: 2px 0px 2px 0px;
}

.view {
    height: 100%;
}

/* .bg-cover {
  padding: 40px;
  width: auto;
  height: auto;
  border-color: black;
  border-style: solid;
  border-width: 2px 0px 2px 0px;
  justify-content: center;
} */

audio{
  margin-top: 20px;
}
</style>
