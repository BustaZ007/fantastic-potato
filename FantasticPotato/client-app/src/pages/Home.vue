<template>
    <div>
        <h1>Hello, {{profile.name}}</h1>
    </div>
</template>

<script>
    export default {
        name: 'home',
        data(){
            return {
                profile: {
                    name: "ERROR"
                }
            }
        },
        mounted() {
            this.$api.get("User/GetUser/" + localStorage.getItem('user-token')).then(res =>{
                this.profile = res.data;
                console.log(res.data);
            });
        }
    }
</script>
