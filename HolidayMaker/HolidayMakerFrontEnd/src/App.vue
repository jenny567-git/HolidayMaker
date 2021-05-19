<template>
  <main>
  <HomeHeader/>
    <div class="container">
        

      
      <router-view/>
    </div>
    <div>
      <Footer/>
    </div>
  </main>
</template>

<script>
// import ConfirmDate from './components/pages/Datepicker/ConfirmDate.vue'
// import Dialog from 'primevue/dialog';
// import InputText from 'primevue/InputText';
// import Button from 'primevue/Button';
// import Menu from 'primevue/menu';
// import ColorPicker from 'primevue/colorpicker';
import HomeHeader from '/src/components/HomeHeader.vue'
import Footer from '/src/components/Footer.vue'

export default {
  name: 'App',
  components: {
    HomeHeader,
    Footer
  },
  data() {
        return {
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
      }
    }
}


</script>

<style src="./assets/style.css"></style>
<style>
#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
  margin-top: 60px;
}

.input-group{
    margin-left: auto;
    margin-right: auto;
    display: flex;
    width: fit-content;
    align-content: center;
}


</style>
