require('./setup').setup();
const core = require('@actions/core');
const semver = require("semver");

const validBumpTypes = ['MAJOR', 'MINOR', 'PATCH'];

function run() {
    const currentVersion = core.getInput('current_version');
    const bumpType = core.getInput('bump_type');

    if (!semver.valid(currentVersion)) {
        console.error(`${currentVersion} : Is not a valid semantic version`);
        process.exit(1);
    }

    if (!validBumpTypes.includes(bumpType)) {
        console.error(`${bumpType} : Is not a valid version bump type`);
        process.exit(1);
    }

    let [major, minor, patch] = currentVersion.split('.');

    switch (bumpType) {
        case 'MAJOR':
            major = parseInt(major);
            major++;
            minor = 0;
            patch = 0;
            break;
        case 'MINOR':
            minor = parseInt(minor);
            minor++;
            patch = 0;
            break;
        case 'PATCH':
            patch = parseInt(patch);
            patch++;
            break;
    }

    newVersion = `${major}.${minor}.${patch}`
    console.log('New Semantic Version:', newVersion)
    core.setOutput('new_version', newVersion);
}

run()