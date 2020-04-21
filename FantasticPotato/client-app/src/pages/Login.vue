<template>
    <div>
        <form class="login" @submit.prevent ="authorization">
            <h1>Sign in</h1>
            <label>Login or email</label>
            <input required v-model="form.login" type="text" placeholder="Name"/>
            <label>Password</label>
            <input required v-model="form.password" type="password" placeholder="Password"/>
            <hr/>
            <button type="submit"></button>
        </form>
    </div>
</template>

<script>
    import myLoginRoutine from '../auth'
    export default {
        data(){ 
            return{
                form: {
                    login: "",
                    password: ""
                }
            }
        },
        methods: {
            authorization(){
                // let dt;
                // let result = this.$api.post("Authorization/Authorization", this.form)
                //     .then(res => {
                //         const token = res.data.token;
                //         localStorage.setItem('user-token', token);
                //         resolve(res);
                //     })
                // .catch(err => {
                //     localStorage.removeItem('user-token');
                //     reject(err);
                // });
                // console.log(result);
                // console.log(dt);
                // this.$router.push('/');
                myLoginRoutine(this.form).then(() => this.$router.push('/'))
            }
        }
    }
</script>
<style>
    #app{
        margin-top: 60px;
    }
</style>