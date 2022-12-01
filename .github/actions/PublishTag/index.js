require('./setup').setup();
const core = require('@actions/core');
const github = require('@actions/github');

async function run() {
  try {
    const GITHUB_TOKEN = core.getInput('GITHUB_TOKEN');
    const octokit = github.getOctokit(GITHUB_TOKEN);
    const { repo, owner } = github?.context?.repo;

    const tag = core.getInput('tag_label');
    const message = core.getInput('tag_message');

    const targetBranch = core.getInput('target_branch');

    if (!tag || !targetBranch) {
      console.error("You are missing a required input:", { targetBranch, tag });
      process.exit(1);
    }


    const response = await octokit.rest.repos.getCommit({
      repo,
      owner,
      ref: targetBranch
    })

    headOfBranch = response?.data?.sha;

    const tagResponse = await octokit.rest.git.createTag({ 
      owner,
      repo,
      tag,
      message,
      object: headOfBranch,
      type: 'commit',
      // TODO:: add tagger for context
    });

    if (tagResponse?.status !== 201) {
      console.error("Unable to creat tag via octokit");
      process.exit(1);
    }

    const refResponse = await octokit.rest.git.createRef({
      owner,
      repo,
      ref: `refs/tags/${tag}`,
      sha: headOfBranch
    })

    if (refResponse?.status !== 201) {
      console.error("Unable to creat tag via octokit");
      process.exit(1);
    }
  } catch (error) {
    core.setFailed(error.message);
  }
}

run();