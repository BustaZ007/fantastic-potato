<template>
    <div>
        <Router></Router>
        <h1>Hello, {{profile.name}}</h1>
    </div>
</template>

<script>
    import Router from '../components/Router'
    export default {
        name: 'home',
        data(){
            return {
                profile: {
                    name: "ERROR"
                }
            }
        },
        components:{
            Router
        },
        mounted() {
            this.$api.get("User/GetUser/" + localStorage.getItem('user-token')).then(res =>{
                this.profile = res.data;
                console.log(res.data);
            });
        }
    }
</script>
