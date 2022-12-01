const child_process = require('child_process');

function setup() {
    console.log('npm install')
    try {
        const buffer = child_process.execSync('npm ci', {cwd: __dirname});
        console.log(buffer.toString("utf-8"))
    } catch (error) {
        console.error(error)
        process.exit(1)
    }
}

module.exports = {
    setup
}