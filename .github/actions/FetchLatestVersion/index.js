require('./setup').setup();
const core = require('@actions/core');
const github = require('@actions/github');
const semver = require('semver');

async function run() {
  try {
    const GITHUB_TOKEN = core.getInput('GITHUB_TOKEN');
    const octokit = github.getOctokit(GITHUB_TOKEN);
    const { repo, owner } = github?.context?.repo;

    let page = 1;
    let latest;

    while (true) {
      const response = await octokit.rest.repos.listTags({
        owner: owner,
        repo,
        page,
        per_page: 100
      });
      if (response.status !== 200) {
        console.err('Error in calling github api.');
        process.exit(1);
      }

      response.data.forEach(tag => {
        // If a tag name is not a valid semantic version skip it
        if (!semver.valid(tag.name)) {
          return;
        }

        // If a latest version has not been set then use this tag
        if (!latest) {
          latest = tag;
          return;
        }

        // If this tag is greater than our prev latest update latest
        latest = semver.gt(tag.name, latest.name) ? tag : latest
      })

      // If the response data length is less than our page size we are at the end
      if (response.data.length < 100) {
        break;
      }

      page++;
    }

    console.log('Latest Semantic Version', latest);

    core.setOutput('latest_version', latest.name)
  } catch (error) {
    core.setFailed(error.message);
  }
}

run();