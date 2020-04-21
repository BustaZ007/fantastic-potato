import Axios from 'axios'

export default user => new Promise ((resolve, reject) => {
    Axios({url: 'http://localhost:5000/Authorization/Authorization', data: user, method: 'POST' })
        .then(resp => {
            const token = resp.data;
            localStorage.setItem('user-token', token.login);
            resolve(resp);
        })
        .catch(err => {
            localStorage.removeItem('user-token');
            reject(err);
        })
});
